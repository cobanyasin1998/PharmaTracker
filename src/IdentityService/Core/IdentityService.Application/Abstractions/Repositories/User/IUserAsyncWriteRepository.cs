using Coban.Application.Repositories.Base.Read;
using Coban.Application.Repositories.Base.Write;
using Coban.Identity.Entities.Base;

namespace IdentityService.Application.Abstractions.Repositories.User;

public interface IUserAsyncWriteRepository : IAsyncWriteRepository<UserEntity>
{
}
