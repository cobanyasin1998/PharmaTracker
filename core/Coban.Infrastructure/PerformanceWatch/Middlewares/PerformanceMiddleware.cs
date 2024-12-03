using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Coban.Infrastructure.PerformanceWatch.Middlewares;

public class PerformanceMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<PerformanceMiddleware> _logger;

    public PerformanceMiddleware(RequestDelegate next, ILogger<PerformanceMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        await _next(context);
        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds > 1000)
        {
            _logger.LogWarning($"Slow request: {context.Request.Method} {context.Request.Path} took {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
