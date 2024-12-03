using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupService.Application.Features.Group.Commands.Create;



public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommandRequest, IResponse<CreateGroupCommandResponse, GeneralErrorDto>>
{
    
    public async Task<IResponse<CreateGroupCommandResponse, GeneralErrorDto>> Handle(CreateGroupCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}
