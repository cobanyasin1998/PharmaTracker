using Coban.Infrastructure.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Coban.Security.Middlewares.BlackList;


public class BlackListControlMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HashSet<string> _blacklist;

    public BlackListControlMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        var blacklist = new List<string>();

        _blacklist= configuration.GetSection("Blacklist").Get<HashSet<string>>() ?? new HashSet<string>();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var remoteIp = context.Connection.RemoteIpAddress?.ToString();

        if (_blacklist.Contains(remoteIp))
            throw new BlackListRuleException("Access Denied: Your is blacklisted.");

        await _next(context);
    }
}
