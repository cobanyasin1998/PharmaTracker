using Coban.Identity.Entities.Base;
using Coban.Persistence.Repositories.EntityFramework.Write;
using IdentityService.Application.Abstractions.Repositories.User;
using IdentityService.Persistence.DbContexts;

namespace IdentityService.Persistence.EntityFramework.Repositories.User;


public class UserAsyncWriteRepository(IdentityDbContext context) : AsyncWriteRepository<UserEntity, IdentityDbContext>(context), IUserAsyncWriteRepository
{
}
