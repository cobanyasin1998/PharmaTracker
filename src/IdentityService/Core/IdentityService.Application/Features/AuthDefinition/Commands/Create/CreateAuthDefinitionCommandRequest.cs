using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Commands.Create;

public class CreateAuthDefinitionCommandRequest : IRequest<IResponse<CreateAuthDefinitionCommandResponse, GeneralErrorDto>>
{
   
}