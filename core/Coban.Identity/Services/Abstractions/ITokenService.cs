using Coban.Identity.Entities.Base;

namespace Coban.Identity.Services.Abstractions;

public interface ITokenService
{
    string GenerateAccessToken(UserEntity user);
    string GenerateRefreshToken();
}
