using Coban.Application.Abstractions.Repositories.Base.Read;
using Coban.Application.Abstractions.Repositories.Base.Write;
using PharmacyService.Domain.Entities;

namespace Coban.Persistence.Repositories.EntityFramework.Abstractions;
public interface IUnitOfWork
{
    //Pharmacy Entity Repository
    IAsyncWriteRepository<PharmacyEntity> AsyncPharmacyWriteRepository { get; }
    IWriteRepository<PharmacyEntity> PharmacyWriteRepository { get; }
    IReadRepository<PharmacyEntity> PharmacyReadRepository { get; }
    IAsyncReadRepository<PharmacyEntity> AsyncPharmacyReadRepository { get; }
    Task<int> SaveChangesAsync();
}
