using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Coban.Infrastructure.Middlewares.RequestResponseLogging;

public class RequestResponseLoggingMiddleware(RequestDelegate _next, ILogger<RequestResponseLoggingMiddleware> _logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Incoming Request: {Method} {Path}", context.Request.Method, context.Request.Path);
        await _next(context);
        _logger.LogInformation("Outgoing Response: {StatusCode}", context.Response.StatusCode);

    }
}
