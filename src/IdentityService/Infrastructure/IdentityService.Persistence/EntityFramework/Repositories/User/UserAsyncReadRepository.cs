using Coban.Identity.Entities.Base;
using Coban.Persistence.Repositories.EntityFramework.Read;
using IdentityService.Application.Abstractions.Repositories.User;
using IdentityService.Persistence.DbContexts;

namespace IdentityService.Persistence.EntityFramework.Repositories.User;


public class UserAsyncReadRepository(IdentityDbContext context) : AsyncReadRepository<UserEntity, IdentityDbContext>(context), IUserAsyncReadRepository
{
}

