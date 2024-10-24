
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PharmacyService.Application.Abstraction.Response;
using System.Net;

namespace PharmacyService.API.Controllers.Base;

public class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    protected IActionResult HandleResponse<T>(T result) where T : IResponseCustom
    {
        return result.HttpStatusCode switch
        {
            HttpStatusCode.BadRequest => BadRequest(new { message = result.Message, errors = result.Errors }),
            HttpStatusCode.NotFound => NotFound(new { message = result.Message }),
            HttpStatusCode.Unauthorized => Unauthorized(new { message = result.Message }),
            HttpStatusCode.OK => Ok(result),
            _ => StatusCode((int)result.HttpStatusCode, new { message = result.Message ?? "An unexpected error occurred." })
        };
    }

}
