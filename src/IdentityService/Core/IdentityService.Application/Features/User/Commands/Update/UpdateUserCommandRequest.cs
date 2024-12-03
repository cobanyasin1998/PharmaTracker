using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserService.Application.Features.User.Commands.Update;

public class UpdateUserCommandRequest : IRequest<IResponse<UpdateUserCommandResponse, GeneralErrorDto>>
{
   
}