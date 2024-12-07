using Coban.Infrastructure.Middlewares.Maintenance;
using Microsoft.AspNetCore.Builder;

namespace Coban.Infrastructure.Middlewares.MaxRequestSize;

public static class MaxRequestSizeMiddlewareExtensions
{
    public static void ConfigureMaxRequestSizeMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<MaintenanceMiddleware>();
}

