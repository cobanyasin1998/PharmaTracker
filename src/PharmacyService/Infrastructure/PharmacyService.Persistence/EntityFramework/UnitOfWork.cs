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
   

    public IAsyncWriteRepository<PharmacyEntity> AsyncPharmacyWriteRepository 
        => new AsyncWriteRepository<PharmacyEntity, PharmacyDbContext>(_context);

    public IWriteRepository<PharmacyEntity> PharmacyWriteRepository 
        => new WriteRepository<PharmacyEntity, PharmacyDbContext>(_context);

    public IReadRepository<PharmacyEntity> PharmacyReadRepository 
        => new ReadRepository<PharmacyEntity, PharmacyDbContext>(_context);

    public IAsyncReadRepository<PharmacyEntity> AsyncPharmacyReadRepository 
        => new AsyncReadRepository<PharmacyEntity, PharmacyDbContext>(_context);

    public async Task<int> SaveChangesAsync() 
        => await _context.SaveChangesAsync();
}
