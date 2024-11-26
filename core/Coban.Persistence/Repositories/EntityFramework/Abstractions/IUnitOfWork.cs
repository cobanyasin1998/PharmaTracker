using Coban.Application.Abstractions.Repositories.Base.Read;
using Coban.Application.Abstractions.Repositories.Base.Write;
using PharmacyService.Domain.Entities;

namespace Coban.Persistence.Repositories.EntityFramework.Abstractions;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
    //Pharmacy Entity Repository
    IAsyncWriteRepository<PharmacyEntity> AsyncPharmacyWriteRepository { get; }
    IWriteRepository<PharmacyEntity> PharmacyWriteRepository { get; }
    IReadRepository<PharmacyEntity> PharmacyReadRepository { get; }
    IAsyncReadRepository<PharmacyEntity> AsyncPharmacyReadRepository { get; }
  
}
