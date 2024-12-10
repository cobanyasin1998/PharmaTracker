using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.Middlewares.CorrelationId;

public class CorrelationIdMiddleware(RequestDelegate _next)
{
    private const string CorrelationIdHeader = "X-Correlation-ID";

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey(CorrelationIdHeader))
        {
            context.Request.Headers[CorrelationIdHeader] = Guid.NewGuid().ToString();
        }

        context.Response.Headers[CorrelationIdHeader] = context.Request.Headers[CorrelationIdHeader];

        await _next(context);
    }
}
