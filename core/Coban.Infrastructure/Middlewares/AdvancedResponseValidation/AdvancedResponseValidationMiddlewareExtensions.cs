using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.AdvancedResponseValidation;

public static class AdvancedResponseValidationMiddlewareExtensions
{
    public static void ConfigureAdvancedResponseValidationMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<AdvancedResponseValidationMiddleware>();
}
