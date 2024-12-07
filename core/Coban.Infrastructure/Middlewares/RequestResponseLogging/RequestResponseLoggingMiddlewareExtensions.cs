using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.RequestResponseLogging;

public static class RequestResponseLoggingMiddlewareExtensions
{
    public static void ConfigureRequestResponseLoggingMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<RequestResponseLoggingMiddleware>();
}
