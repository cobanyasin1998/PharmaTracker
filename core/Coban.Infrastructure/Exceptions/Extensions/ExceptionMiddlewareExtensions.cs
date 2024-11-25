using Coban.Infrastructure.Exceptions.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Exceptions.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionMiddleware>();
}
