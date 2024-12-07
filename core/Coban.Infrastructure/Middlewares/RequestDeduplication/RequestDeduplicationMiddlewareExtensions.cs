using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.RequestDeduplication;

public static class RequestDeduplicationMiddlewareExtensions
{
    public static void ConfigureRequestDeduplicationMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<RequestDeduplicationMiddleware>();
}
