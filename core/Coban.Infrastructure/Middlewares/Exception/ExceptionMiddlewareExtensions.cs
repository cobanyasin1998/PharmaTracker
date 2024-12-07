using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.Exception;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionMiddleware>();
}
