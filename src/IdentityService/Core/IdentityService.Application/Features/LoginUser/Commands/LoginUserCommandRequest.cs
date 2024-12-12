using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace IdentityService.Application.Features.LoginUser.Commands;

public class LoginUserCommandRequest: IRequest<IResponse<LoginUserCommandResponse, GeneralErrorDto>>
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}
