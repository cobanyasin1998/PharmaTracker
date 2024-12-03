using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Create;

public class CreateGroupAuthDefinitionCommandHandler : IRequestHandler<CreateGroupAuthDefinitionCommandRequest, IResponse<CreateGroupAuthDefinitionCommandResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<CreateGroupAuthDefinitionCommandResponse, GeneralErrorDto>> Handle(CreateGroupAuthDefinitionCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}
