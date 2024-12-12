using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using Coban.Presentation.Controllers.Abstractions;
using IdentityService.Application.Features.LoginUser.Commands;
using IdentityService.Application.Features.User.Commands.Create;
using IdentityService.Application.Features.User.Commands.Delete;
using IdentityService.Application.Features.User.Commands.Update;
using IdentityService.Application.Features.User.Queries.GetAll;
using IdentityService.Application.Features.User.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers;


public class UserController : AbstractController<
    CreateUserCommandRequest,
    UpdateUserCommandRequest,
    DeleteUserCommandRequest,
    GetByIdUserQueryRequest,
    GetAllUserQueryRequest
    >
{
    [HttpPost]
    public virtual async Task<IActionResult> LoginUser([FromBody] LoginUserCommandRequest loginUserCommandRequest)
    {
        IResponse<LoginUserCommandResponse,GeneralErrorDto>? response = await Mediator!.Send(loginUserCommandRequest);
        return HandleResponse((IResponseBase)response);
    }

   

}
