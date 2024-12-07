using Coban.Infrastructure.Exceptions.ExceptionTypes;
using Coban.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.Middlewares.AdvancedRequestValidation;

public class AdvancedRequestValidationMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.HasJsonContentType())
            throw new InvalidRequestException("Invalid request format.");

        await _next(context);
    }
}
