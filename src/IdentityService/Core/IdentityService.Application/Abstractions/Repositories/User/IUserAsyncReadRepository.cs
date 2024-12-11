using Coban.Application.Repositories.Base.Read;
using Coban.Identity.Entities.Base;

namespace IdentityService.Application.Abstractions.Repositories.User;

public interface IUserAsyncReadRepository : IAsyncReadRepository<UserEntity>
{
}
