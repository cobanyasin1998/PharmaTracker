using Coban.Infrastructure.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Coban.Infrastructure.Middlewares.BlackList;


public class BlackListControlMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private readonly RequestDelegate _next = next;
    private readonly HashSet<string> _blacklist = configuration.GetSection("Blacklist").Get<HashSet<string>>() ?? new HashSet<string>();

    public async Task InvokeAsync(HttpContext context)
    {
        string? remoteIp = context.Connection.RemoteIpAddress?.ToString();

        if (_blacklist.Contains(remoteIp))
            throw new BlackListRuleException("Access Denied: Your is blacklisted.");

        await _next(context);
    }
}

