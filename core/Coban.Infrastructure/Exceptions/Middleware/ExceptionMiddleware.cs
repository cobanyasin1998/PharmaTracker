using Coban.Infrastructure.Exceptions.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Coban.Infrastructure.Exceptions.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpExceptionHandler _httpExceptionHandler;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _httpExceptionHandler = new HttpExceptionHandler();
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        await _httpExceptionHandler.HandleExceptionAsync(exception, context);
    }
}
