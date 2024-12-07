using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.BotDetection;

public static class BotDetectionMiddlewareExtensions
{
    public static void ConfigureBotDetectionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<BotDetectionMiddleware>();
}
