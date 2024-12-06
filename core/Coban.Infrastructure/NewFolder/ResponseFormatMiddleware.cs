using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Coban.Infrastructure.NewFolder;

public class ResponseFormatMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseFormatMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // HTTP yanıtını yakalamak için bir bellek akışı oluştur
        Stream? originalResponseBodyStream = context.Response.Body;
        using MemoryStream? memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        try
        {
            // Middleware zincirinde ilerle
            await _next(context);

            // Yanıt akışını sıfırla ve oku
            memoryStream.Seek(0, SeekOrigin.Begin);
            string responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
            memoryStream.Seek(0, SeekOrigin.Begin);

            // Response'u JSON olarak parse etmeye çalış
            object? parsedResponse;
            try
            {
                parsedResponse = JsonSerializer.Deserialize<object>(responseBody);
            }
            catch
            {
                parsedResponse = null; // JSON olmayan bir yapı geldi
            }

            // Yanlış formatta bir response dönerse standardize et
            if (parsedResponse == null || !responseBody.Contains("Data") || !responseBody.Contains("Success"))
            {
                var errorResponse = new
                {
                    Data = (object?)null,
                    Errors = new[]
                    {
                        new
                        {
                            ErrorMessage = "Yanlış dönüş tipi kullanıldı.",
                            Details = responseBody
                        }
                    },
                    Success = false,
                    Message = "Yazılımcı hatası",
                    Timestamp = DateTime.UtcNow,
                    ErrorType = 602 // Özel hata tipi
                };

                // Standardize edilmiş yanıtı döndür
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var standardizedResponse = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(standardizedResponse);

                return;
            }

            // Orijinal yanıtı geri döndür
            memoryStream.Seek(0, SeekOrigin.Begin);
            await memoryStream.CopyToAsync(originalResponseBodyStream);
        }
        finally
        {
            context.Response.Body = originalResponseBodyStream;
        }
    }
}