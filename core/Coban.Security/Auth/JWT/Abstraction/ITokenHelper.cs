using Coban.Security.Auth.JWT.Concretes;

namespace Coban.Security.Auth.JWT.Abstraction;

public interface ITokenHelper
{
    AccessToken CreateToken(long userId);
   // RefreshToken CreateRefreshToken(long userId, string ipAddress);
}