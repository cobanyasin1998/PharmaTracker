using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Update;

public class UpdateGroupAuthDefinitionCommandRequest : IRequest<IResponse<UpdateGroupAuthDefinitionCommandResponse, GeneralErrorDto>>
{
   
}