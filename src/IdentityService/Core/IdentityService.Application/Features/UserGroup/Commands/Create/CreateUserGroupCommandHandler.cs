using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserGroupService.Application.Features.UserGroup.Commands.Create;



public class CreateUserGroupCommandHandler : IRequestHandler<CreateUserGroupCommandRequest, IResponse<CreateUserGroupCommandResponse, GeneralErrorDto>>
{
    
    public async Task<IResponse<CreateUserGroupCommandResponse, GeneralErrorDto>> Handle(CreateUserGroupCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}
