using Coban.Consts;
using Coban.Infrastructure.Exceptions.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Coban.Infrastructure.Middlewares.Exception;


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
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, System.Exception exception)
    {
        context.Response.ContentType = GeneralOperationConsts.ApplicationJsonKey;

        await _httpExceptionHandler.HandleExceptionAsync(exception, context);
    }
}
