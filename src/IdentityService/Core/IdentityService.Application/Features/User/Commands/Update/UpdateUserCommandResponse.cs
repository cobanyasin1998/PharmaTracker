using Coban.Application.Responses;

namespace IdentityService.Application.Features.User.Commands.Update;

public class UpdateUserCommandResponse : BaseResponse
{
    public UpdateUserCommandResponse(long Id)
    {
        this.Id = Id;
    }
}