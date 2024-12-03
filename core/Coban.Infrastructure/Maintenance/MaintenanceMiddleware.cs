using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Coban.Infrastructure.Maintenance;

public class MaintenanceMiddleware
{
    private readonly RequestDelegate _next;
    private readonly bool _isInMaintenance;

    public MaintenanceMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _isInMaintenance = config.GetValue<bool>("MaintenanceMode");
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (_isInMaintenance)
        {
            context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            await context.Response.WriteAsync("Service is under maintenance. Please try again later.");
            return;
        }

        await _next(context);
    }
}
