using Coban.Application.Abstractions.Repositories.Base.Read;
using Coban.Application.Abstractions.Repositories.Base.Write;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using Coban.Persistence.Repositories.EntityFramework.Read;
using Coban.Persistence.Repositories.EntityFramework.Write;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework;

public class UnitOfWork : IUnitOfWork
{
    private readonly PharmacyDbContext _context;

    public UnitOfWork(PharmacyDbContext context) 
        => _context = context;

    #region Save Methods
    public int SaveChanges()
    => _context.SaveChanges();
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
    #endregion

    #region Pharmacy
    public IAsyncWriteRepository<PharmacyEntity> PharmacyWriteRepository
      => new AsyncWriteRepository<PharmacyEntity, PharmacyDbContext>(_context);
    public IAsyncReadRepository<PharmacyEntity> PharmacyReadRepository
        => new AsyncReadRepository<PharmacyEntity, PharmacyDbContext>(_context);
    #endregion

    #region Pharmacy Branch
    public IAsyncWriteRepository<PharmacyBranchEntity> PharmacyBranchWriteRepository
      => new AsyncWriteRepository<PharmacyBranchEntity, PharmacyDbContext>(_context);

    public IAsyncReadRepository<PharmacyBranchEntity> PharmacyBranchReadRepository
       => new AsyncReadRepository<PharmacyBranchEntity, PharmacyDbContext>(_context);
    #endregion

    #region Pharmacy Branch Contact
    public IAsyncWriteRepository<PharmacyBranchContactEntity> PharmacyBranchContactWriteRepository
     => new AsyncWriteRepository<PharmacyBranchContactEntity, PharmacyDbContext>(_context);

    public IAsyncReadRepository<PharmacyBranchContactEntity> PharmacyBranchContactReadRepository
       => new AsyncReadRepository<PharmacyBranchContactEntity, PharmacyDbContext>(_context);
    #endregion

    #region Pharmacy Branch Address
    public IAsyncWriteRepository<PharmacyBranchAddressEntity> PharmacyBranchAddressWriteRepository
  => new AsyncWriteRepository<PharmacyBranchAddressEntity, PharmacyDbContext>(_context);

    public IAsyncReadRepository<PharmacyBranchAddressEntity> PharmacyBranchAddressReadRepository
       => new AsyncReadRepository<PharmacyBranchAddressEntity, PharmacyDbContext>(_context);
    #endregion

}
