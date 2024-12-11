using Coban.Application.Responses;

namespace IdentityService.Application.Features.User.Commands.Create;

public class CreateUserCommandResponse : BaseResponse
{
    public CreateUserCommandResponse(long Id)
    {
        this.Id = Id;
    }
}

