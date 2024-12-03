using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Update;



public class UpdateGroupAuthDefinitionCommandHandler : IRequestHandler<UpdateGroupAuthDefinitionCommandRequest, IResponse<UpdateGroupAuthDefinitionCommandResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<UpdateGroupAuthDefinitionCommandResponse, GeneralErrorDto>> Handle(UpdateGroupAuthDefinitionCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}