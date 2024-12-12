namespace IdentityService.Application.Features.LoginUser.Commands;

public class LoginUserCommandResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
