using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Commands.Delete;



public class DeleteAuthDefinitionCommandHandler : IRequestHandler<DeleteAuthDefinitionCommandRequest, IResponse<DeleteAuthDefinitionCommandResponse, GeneralErrorDto>>
{
    
    public async Task<IResponse<DeleteAuthDefinitionCommandResponse, GeneralErrorDto>> Handle(DeleteAuthDefinitionCommandRequest request, CancellationToken cancellationToken)
    {
       
       throw new Exception("Not Implemented");
    }
}