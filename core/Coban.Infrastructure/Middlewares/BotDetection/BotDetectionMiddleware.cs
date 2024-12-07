using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.Middlewares.BotDetection;

public class BotDetectionMiddleware
{
    private readonly RequestDelegate _next;

    public BotDetectionMiddleware(RequestDelegate next) 
        => _next = next;
    

    public async Task InvokeAsync(HttpContext context)
    {
        string userAgent = context.Request.Headers["User-Agent"].ToString();

        if (IsBot(userAgent))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Access denied: Bots are not allowed.");
            return;
        }

        await _next(context);
    }

    private static bool IsBot(string userAgent)
    {
        string[] botIndicators = { "bot", "spider", "crawler", "curl", "wget" };
        return botIndicators.Any(userAgent.ToLower().Contains);
    }
}
