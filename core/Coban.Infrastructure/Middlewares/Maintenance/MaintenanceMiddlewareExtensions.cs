using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.Maintenance;

public static class MaintenanceMiddlewareExtensions
{
    public static void ConfigureMaintenanceMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<MaintenanceMiddleware>();
}
