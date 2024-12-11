using Coban.Application.Responses;

namespace IdentityService.Application.Features.User.Commands.Delete;


public class DeleteUserCommandResponse : BaseResponse
{
    public DeleteUserCommandResponse(long Id)
    {
        this.Id = Id;
    }
}
