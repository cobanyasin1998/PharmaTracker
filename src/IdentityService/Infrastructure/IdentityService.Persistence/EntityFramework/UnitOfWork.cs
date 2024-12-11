using Coban.Application.Repositories.Base.Read;
using Coban.Application.Repositories.Base.Write;
using Coban.Identity.Entities.Base;
using Coban.Persistence.Repositories.EntityFramework.Read;
using Coban.Persistence.Repositories.EntityFramework.Write;
using IdentityService.Application.Abstractions.UnitOfWork;
using IdentityService.Persistence.DbContexts;

namespace IdentityService.Persistence.EntityFramework;

public class UnitOfWork(IdentityDbContext _context) : IUnitOfWork
{
    #region Save Methods
    public int SaveChanges()
    => _context.SaveChanges();
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
    #endregion

    #region User
    public IAsyncWriteRepository<UserEntity> UserWriteRepository
      => new AsyncWriteRepository<UserEntity, IdentityDbContext>(_context);
    public IAsyncReadRepository<UserEntity> UserReadRepository
        => new AsyncReadRepository<UserEntity, IdentityDbContext>(_context);
    #endregion

  

}
