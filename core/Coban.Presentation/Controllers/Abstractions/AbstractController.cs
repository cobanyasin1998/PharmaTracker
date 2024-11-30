using Coban.Application.Responses.Base.Abstractions;
using Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;
using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class AbstractController<
    TCreateReq, TCreateRes,
    TUpdateReq, TUpdateRes,
     TDeleteReq, TDeleteRes,
    TGetByIdReq, TGetByIdRes,
    TGetAllReq, TGetAllRes> : BaseController,
    ICreateController<TCreateReq, TCreateRes>,
    IUpdateController<TUpdateReq, TUpdateRes>,
    IDeleteController<TDeleteReq, TDeleteRes>,
    IGetByIdController<TGetByIdReq, TGetByIdRes>,
    IGetAllController<TGetAllReq, TGetAllRes>
    where TCreateRes : IResponseBase
    where TUpdateRes : IResponseBase
    where TDeleteRes : IResponseBase
    where TGetByIdRes : IResponseBase
    where TGetAllRes: IResponseBase
{
    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] TCreateReq request)
    {
        var response = await Mediator!.Send(request);
        return HandleResponse((IResponseBase)response);
    }

    [HttpPut]
    public virtual async Task<IActionResult> Update([FromBody] TUpdateReq request)
    {
        var response = await Mediator.Send(request);
        return HandleResponse((IResponseBase)response);
    }

    [HttpPost]
    public virtual async Task<IActionResult> GetById([FromBody] TGetByIdReq getByIdRequest)
    {

        var response = await Mediator!.Send(getByIdRequest);
        return HandleResponse((IResponseBase)response);
    }

    [HttpPost]
    public virtual async Task<IActionResult> GetAll([FromBody] TGetAllReq request)
    {
        var response = await Mediator!.Send(request);
        return HandleResponse((IResponseBase)response);
    }
    [HttpPost]
    public virtual async Task<IActionResult> Delete([FromBody] TDeleteReq deleteRequest)
    {
        var response = await Mediator!.Send(deleteRequest);
        return HandleResponse((IResponseBase)response);
    }
}
