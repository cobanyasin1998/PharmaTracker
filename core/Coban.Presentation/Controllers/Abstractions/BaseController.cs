using Coban.Application.Responses.Base.Abstractions;
using Coban.Consts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Coban.Presentation.Controllers.Abstractions;

public class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


    protected IActionResult HandleResponse<T>(T result) where T : IResponseBase
    {
        return result.HttpStatusCode switch
        {
            StatusCodes.Status400BadRequest => BadRequest(result),
            StatusCodes.Status404NotFound => NotFound(result),
            StatusCodes.Status401Unauthorized => Unauthorized(result),
            StatusCodes.Status200OK => Ok(result),
            _ => StatusCode(result.HttpStatusCode, new
            {
                message = result.Message ?? GeneralOperationConsts.AnUnexpectedErrorOccurred
            })
        };
    }
}
