using Coban.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Coban.Infrastructure.Middlewares.Maintenance;

public class MaintenanceMiddleware(RequestDelegate _next, IConfiguration config)
{
    private readonly bool _isInMaintenance = config.GetValue<bool>(MaintenanceModeKey);
    private const String MaintenanceModeKey = "MaintenanceMode";

    public async Task InvokeAsync(HttpContext context)
    {
        if (_isInMaintenance)
            throw new MaintenanceServiceUnavailableException("Service is under maintenance. Please try again later.");
        await _next(context);
    }
}
