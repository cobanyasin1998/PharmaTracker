﻿using Coban.Consts;
using Newtonsoft.Json;

namespace Coban.Application.SyncCommunication;

public static class DynamicHttpClient
{
    private static readonly HttpClient _httpClient = new(
        new HttpClientHandler()
        {
            MaxConnectionsPerServer = 100,
            AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
        })
    {
        Timeout = TimeSpan.FromSeconds(30)
    };

    public static async Task<T?> SendRequestAsync<T>(string url, HttpMethod method, object data, string? token = null, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpRequestMessage requestMessage = new()
            {
                RequestUri = new Uri(url),
                Method = method
            };

            if (!string.IsNullOrEmpty(token))
            {
                requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            if (data is not null && (method == HttpMethod.Post || method == HttpMethod.Put))
            {
                string jsonContent = JsonConvert.SerializeObject(data);
                requestMessage.Content = new StringContent(jsonContent, System.Text.Encoding.UTF8, GeneralOperationConsts.ApplicationJsonKey);
            }

            HttpResponseMessage response = await _httpClient.SendAsync(requestMessage, cancellationToken);
            response.EnsureSuccessStatusCode();

            string responseData = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<T?>(responseData);
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine($"{HttpClientConsts.RequestTimeout} {ex.Message}");
            throw;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"{HttpClientConsts.RequestFailed} {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{GeneralOperationConsts.AnUnexpectedErrorOccurred} {ex.Message}");
            throw;
        }
    }
}
