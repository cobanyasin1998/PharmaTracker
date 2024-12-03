using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Commands.Create;



public class CreateAuthDefinitionCommandHandler : IRequestHandler<CreateAuthDefinitionCommandRequest, IResponse<CreateAuthDefinitionCommandResponse, GeneralErrorDto>>
{
  
    public async Task<IResponse<CreateAuthDefinitionCommandResponse, GeneralErrorDto>> Handle(CreateAuthDefinitionCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}
