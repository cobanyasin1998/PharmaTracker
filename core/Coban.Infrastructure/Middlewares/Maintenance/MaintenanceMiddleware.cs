using Coban.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Coban.Infrastructure.Middlewares.Maintenance;

public class MaintenanceMiddleware
{
    private readonly RequestDelegate _next;
    private readonly bool _isInMaintenance;
    private const string MaintenanceModeKey = "MaintenanceMode";
    public MaintenanceMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _isInMaintenance = config.GetValue<bool>(MaintenanceModeKey);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (_isInMaintenance)
            throw new MaintenanceServiceUnavailableException("Service is under maintenance. Please try again later.");
        await _next(context);
    }
}
