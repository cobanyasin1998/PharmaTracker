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
            StatusCodes.Status400BadRequest => BadRequest(new { message = result.Message }),
            StatusCodes.Status404NotFound => NotFound(new { message = result.Message }),
            StatusCodes.Status401Unauthorized => Unauthorized(new { message = result.Message }),
            StatusCodes.Status200OK => Ok(result),
            _ => StatusCode((int)result.HttpStatusCode, new
            {
                message = result.Message ?? GeneralOperationConsts.AnUnexpectedErrorOccurred
            })
        };
    }
}
