using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserGroupService.Application.Features.UserGroup.Commands.Update;



public class UpdateUserGroupCommandHandler : IRequestHandler<UpdateUserGroupCommandRequest, IResponse<UpdateUserGroupCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<UpdateUserGroupCommandResponse, GeneralErrorDto>> Handle(UpdateUserGroupCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}