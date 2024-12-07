using Coban.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.Middlewares.RequestDeduplication;

public class RequestDeduplicationMiddleware
{
    private readonly RequestDelegate _next;
    private static Dictionary<string, DateTime> _recentRequests = new();

    public RequestDeduplicationMiddleware(RequestDelegate next) 
        => _next = next;
   

    public async Task InvokeAsync(HttpContext context)
    {
        var ipAddress = context.Connection.RemoteIpAddress.ToString();
        if (_recentRequests.ContainsKey(ipAddress) && (DateTime.Now - _recentRequests[ipAddress]).TotalSeconds < 4)
            throw new TooManyRequestException("Duplicate request detected, try again later.");

        _recentRequests[ipAddress] = DateTime.Now;
        await _next(context);
    }
}