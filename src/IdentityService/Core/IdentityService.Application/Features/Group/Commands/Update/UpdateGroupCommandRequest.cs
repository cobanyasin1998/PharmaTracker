using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupService.Application.Features.Group.Commands.Update;

public class UpdateGroupCommandRequest : IRequest<IResponse<UpdateGroupCommandResponse, GeneralErrorDto>>
{
   
}