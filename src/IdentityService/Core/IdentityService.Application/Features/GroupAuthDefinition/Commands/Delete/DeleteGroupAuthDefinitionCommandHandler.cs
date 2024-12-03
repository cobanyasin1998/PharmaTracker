using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Delete;



public class DeleteGroupAuthDefinitionCommandHandler : IRequestHandler<DeleteGroupAuthDefinitionCommandRequest, IResponse<DeleteGroupAuthDefinitionCommandResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<DeleteGroupAuthDefinitionCommandResponse, GeneralErrorDto>> Handle(DeleteGroupAuthDefinitionCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}