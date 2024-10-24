using MediatR;
using Microsoft.AspNetCore.Mvc;
using PharmacyService.Application.Abstraction.Response;

namespace PharmacyService.API.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public abstract class AbstractController<TCreateRequest, TUpdateRequest, TGetByIdRequest, TResponse> : BaseController
     where TResponse : IResponseCustom
{
    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] TCreateRequest request)
    {
        var response = (TResponse)await Mediator.Send(request);
        return HandleResponse(response);
    }
    [HttpPut]
    public virtual async Task<IActionResult> Update([FromBody] TUpdateRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }

    //[HttpGet]
    //public virtual async Task<IActionResult> GetAll()
    //{
    //    var response = await _mediator.Send(new GetAllQueryRequest()); // Spesifik bir GetAllRequest yaratabilirsiniz
    //    return Ok(response);
    //}

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(long id)
    {
        var response = await Mediator.Send((TGetByIdRequest)Activator.CreateInstance(typeof(TGetByIdRequest), id));
        return Ok(response);
    }
}
