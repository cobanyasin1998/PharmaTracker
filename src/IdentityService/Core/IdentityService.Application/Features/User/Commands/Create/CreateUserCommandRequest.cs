using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace IdentityService.Application.Features.User.Commands.Create;

public class CreateUserCommandRequest : Coban.Application.Requests.IBaseRequest, IRequest<IResponse<CreateUserCommandResponse, GeneralErrorDto>>
{

}