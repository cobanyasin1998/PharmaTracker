using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Coban.Infrastructure.Middlewares.MaxRequestSize;

public class MaxRequestSizeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly long _maxRequestSizeInBytes;
    private const string MaxRequestSize = "MaxRequestSize";

    public MaxRequestSizeMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _maxRequestSizeInBytes = config.GetValue<int>(MaxRequestSize) * 1024 * 1024;
    }

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