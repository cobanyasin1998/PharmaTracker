using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.DynamicRateLimiting;

public class DynamicRateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly Dictionary<string, int> RateLimits = new Dictionary<string, int>
{
    { "user1", 100 },  // User1 için 100 istek
    { "user2", 200 }   // User2 için 200 istek
};

    public DynamicRateLimitingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string user = context.User.Identity.Name ?? "guest";
        int limit = RateLimits.ContainsKey(user) ? RateLimits[user] : 50;

        string ip = context.Connection.RemoteIpAddress?.ToString();
        string cacheKey = $"{user}:{ip}";

      
        if (IsRateLimited(cacheKey, limit))
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            await context.Response.WriteAsync("Rate limit exceeded.");
            return;
        }

        await _next(context);
    }

    private static bool IsRateLimited(string cacheKey, int limit)
    {
        // Burada, belirli bir cache (Redis, MemoryCache vb.) kullanarak limit kontrolü yapılabilir.
        return false; // Örnek olarak her zaman geçerli
    }
}
