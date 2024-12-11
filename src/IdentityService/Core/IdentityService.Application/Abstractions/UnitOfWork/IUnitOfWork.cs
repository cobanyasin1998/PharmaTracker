using Coban.Application.Repositories.Base.Read;
using Coban.Application.Repositories.Base.Write;
using Coban.Application.UnitOfWork;
using Coban.Identity.Entities.Base;

namespace IdentityService.Application.Abstractions.UnitOfWork;

public  interface IUnitOfWork : IUnitOfWorkTransaction
{    

    IAsyncWriteRepository<UserEntity> UserWriteRepository { get; }
    IAsyncReadRepository<UserEntity> UserReadRepository { get; }
}
