using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Create;

public class CreateGroupAuthDefinitionCommandRequest : IRequest<IResponse<CreateGroupAuthDefinitionCommandResponse, GeneralErrorDto>>
{
   
}