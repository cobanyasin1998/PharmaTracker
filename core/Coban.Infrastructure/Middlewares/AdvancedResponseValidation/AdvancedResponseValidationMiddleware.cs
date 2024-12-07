using Coban.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Coban.Infrastructure.Middlewares.AdvancedResponseValidation;

public class AdvancedResponseValidationMiddleware
{
    private readonly RequestDelegate _next;

    public AdvancedResponseValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Stream? originalResponseBodyStream = context.Response.Body;
        using MemoryStream? memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        try
        {
            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);
            string responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
            memoryStream.Seek(0, SeekOrigin.Begin);

            object? parsedResponse;
            try
            {
                parsedResponse = JsonSerializer.Deserialize<JsonElement>(responseBody);

                if (parsedResponse is not JsonElement jsonElement)
                    throw new InvalidResponseException("Invalid response format: Expected Response<TData, TErrorDTO> structure.");

                string[] requiredProperties = { "Data", "Errors", "Message", "Success" };
                foreach (String property in requiredProperties)
                {
                    if (!jsonElement.TryGetProperty(property, out _))
                        throw new InvalidResponseException($"Invalid response format: Missing required property '{property}'.");
                }
            }
            catch (System.Exception ex)
            {
                throw new InvalidResponseException("Invalid response format: Expected Response<TData, TErrorDTO> structure.", ex);
            }


            memoryStream.Seek(0, SeekOrigin.Begin);
            await memoryStream.CopyToAsync(originalResponseBodyStream);
        }
        finally
        {
            context.Response.Body = originalResponseBodyStream;
        }
    }
}