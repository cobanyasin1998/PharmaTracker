using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.BlackList;

public static class BlackListControlMiddlewareExtensions
{
    public static void ConfigureCustomBlackListControlMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<BlackListControlMiddleware>();
}
