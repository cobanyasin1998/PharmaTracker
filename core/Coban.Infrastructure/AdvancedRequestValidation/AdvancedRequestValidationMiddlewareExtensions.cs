using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.AdvancedRequestValidation;


public static class AdvancedRequestValidationMiddlewareExtensions
{
    public static void ConfigureAdvancedRequestValidationMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<AdvancedRequestValidationMiddleware>();
}
