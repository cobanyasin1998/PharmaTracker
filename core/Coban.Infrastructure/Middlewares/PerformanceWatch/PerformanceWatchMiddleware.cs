using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Coban.Infrastructure.Middlewares.PerformanceWatch;

public class PerformanceWatchMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<PerformanceWatchMiddleware> _logger;

    public PerformanceWatchMiddleware(RequestDelegate next, ILogger<PerformanceWatchMiddleware> logger)
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
            double elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;
            _logger.LogWarning($"Slow request: {context.Request.Method} {context.Request.Path} took {elapsedSeconds:F2} seconds");
        }

    }
}
