using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserService.Application.Features.User.Commands.Create;

public class CreateUserCommandRequest : IRequest<IResponse<CreateUserCommandResponse, GeneralErrorDto>>
{
   
}