using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserGroupService.Application.Features.UserGroup.Commands.Delete;



public class DeleteUserGroupCommandHandler : IRequestHandler<DeleteUserGroupCommandRequest, IResponse<DeleteUserGroupCommandResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<DeleteUserGroupCommandResponse, GeneralErrorDto>> Handle(DeleteUserGroupCommandRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}