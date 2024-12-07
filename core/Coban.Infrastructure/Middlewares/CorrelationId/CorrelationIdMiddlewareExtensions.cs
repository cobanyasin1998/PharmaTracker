using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.CorrelationId;


public static class CorrelationIdMiddlewareExtensions
{
    public static void ConfigureCorrelationIdMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<CorrelationIdMiddleware>();
}
