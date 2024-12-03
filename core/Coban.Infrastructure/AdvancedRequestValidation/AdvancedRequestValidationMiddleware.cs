using Coban.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.AdvancedRequestValidation;

public class AdvancedRequestValidationMiddleware
{
    private readonly RequestDelegate _next;

    public AdvancedRequestValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.HasJsonContentType())
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Invalid request format.");
            return;
        }

        await _next(context);
    }
}

