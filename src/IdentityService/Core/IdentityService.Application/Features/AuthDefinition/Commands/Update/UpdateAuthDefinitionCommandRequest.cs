using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Commands.Update;

public class UpdateAuthDefinitionCommandRequest : IRequest<IResponse<UpdateAuthDefinitionCommandResponse, GeneralErrorDto>>
{
   
}