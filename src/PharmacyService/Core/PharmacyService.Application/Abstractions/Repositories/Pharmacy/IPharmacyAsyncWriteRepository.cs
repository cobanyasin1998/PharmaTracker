using Coban.Application.Abstractions.Repositories.Base.Write;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Abstractions.Repositories.Pharmacy;

public interface IPharmacyAsyncWriteRepository : IAsyncWriteRepository<PharmacyEntity>
{
}

