using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupService.Application.Features.Group.Commands.Create;

public class CreateGroupCommandRequest : IRequest<IResponse<CreateGroupCommandResponse, GeneralErrorDto>>
{
   
}