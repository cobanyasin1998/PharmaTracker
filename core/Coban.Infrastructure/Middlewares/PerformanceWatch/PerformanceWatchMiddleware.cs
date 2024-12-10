using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Coban.Infrastructure.Middlewares.PerformanceWatch;

public class PerformanceWatchMiddleware(RequestDelegate _next, ILogger<PerformanceWatchMiddleware> _logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        await _next(context);
        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds > 1000)
        {
            double elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000.0;

            _logger.LogWarning(
                "Slow request: {Method} {Path} took {ElapsedSeconds} seconds",
                context.Request.Method,
                context.Request.Path,
                elapsedSeconds
            );
        }

    }
}
