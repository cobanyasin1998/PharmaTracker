using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Commands.Update;



public class UpdateAuthDefinitionCommandHandler : IRequestHandler<UpdateAuthDefinitionCommandRequest, IResponse<UpdateAuthDefinitionCommandResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<UpdateAuthDefinitionCommandResponse, GeneralErrorDto>> Handle(UpdateAuthDefinitionCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}