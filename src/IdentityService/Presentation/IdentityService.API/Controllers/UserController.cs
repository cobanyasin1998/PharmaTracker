using Coban.Presentation.Controllers.Abstractions;
using IdentityService.Application.Features.User.Commands.Create;
using IdentityService.Application.Features.User.Commands.Delete;
using IdentityService.Application.Features.User.Commands.Update;
using IdentityService.Application.Features.User.Queries.GetAll;
using IdentityService.Application.Features.User.Queries.GetById;

namespace IdentityService.API.Controllers;


public class UserController : AbstractController<
    CreateUserCommandRequest,
    UpdateUserCommandRequest,
    DeleteUserCommandRequest,
    GetByIdUserQueryRequest,
    GetAllUserQueryRequest
    >
{
   
}
