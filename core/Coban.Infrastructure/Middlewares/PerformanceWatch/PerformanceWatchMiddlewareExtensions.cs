using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.PerformanceWatch;

public static class PerformanceWatchMiddlewareExtensions
{
    public static void ConfigurePerformanceWatchMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<PerformanceWatchMiddleware>();
}
