using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Coban.Infrastructure.Middlewares.MaxRequestSize;

public class MaxRequestSizeMiddleware(RequestDelegate _next, IConfiguration config)
{
    private readonly long _maxRequestSizeInBytes = config.GetValue<int>(MaxRequestSize) * 1024 * 1024;
    private const string MaxRequestSize = "MaxRequestSize";

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.ContentLength.HasValue && context.Request.ContentLength.Value > _maxRequestSizeInBytes)
        {
            context.Response.StatusCode = StatusCodes.Status413PayloadTooLarge;
            await context.Response.WriteAsync($"Request body exceeds maximum allowed size of {_maxRequestSizeInBytes / (1024 * 1024)} MB.");
            return;
        }
        await _next(context);
    }
}