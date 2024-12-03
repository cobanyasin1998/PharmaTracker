using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.LoginAttemptTracking;

public class LoginAttemptTrackingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly Dictionary<string, int> FailedLoginAttempts = new Dictionary<string, int>();
    private const int MaxAttempts = 5;

    public LoginAttemptTrackingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string username = context.Request.Form["username"].ToString();

        if (FailedLoginAttempts.ContainsKey(username) && FailedLoginAttempts[username] >= MaxAttempts)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Too many failed login attempts. Please try again later.");
            return;
        }

        await _next(context);
    }
}
