using Coban.Application.Responses.Base.Abstractions;
using Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;
using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class AbstractController<
    TCreateReq,
    TUpdateReq,
     TDeleteReq,
    TGetByIdReq,
    TGetAllReq> : BaseController,
    ICreateController<TCreateReq>,
    IUpdateController<TUpdateReq>,
    IDeleteController<TDeleteReq>,
    IGetByIdController<TGetByIdReq>,
    IGetAllController<TGetAllReq>
{
    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] TCreateReq request)
    {
        object? response = await Mediator!.Send(request);
        return HandleResponse((IResponseBase)response);
    }

    [HttpPut]
    public virtual async Task<IActionResult> Update([FromBody] TUpdateReq request)
    {
        object? response = await Mediator.Send(request);
        return HandleResponse((IResponseBase)response);
    }

    [HttpPost]
    public virtual async Task<IActionResult> GetById([FromBody] TGetByIdReq getByIdRequest)
    {

        object? response = await Mediator!.Send(getByIdRequest);
        return HandleResponse((IResponseBase)response);
    }

    [HttpPost]
    public virtual async Task<IActionResult> GetAll([FromBody] TGetAllReq request)
    {
        object? response = await Mediator!.Send(request);
        return HandleResponse((IResponseBase)response);
    }
    [HttpPost]
    public virtual async Task<IActionResult> Delete([FromBody] TDeleteReq deleteRequest)
    {
        object? response = await Mediator!.Send(deleteRequest);
        return HandleResponse((IResponseBase)response);
    }
}
