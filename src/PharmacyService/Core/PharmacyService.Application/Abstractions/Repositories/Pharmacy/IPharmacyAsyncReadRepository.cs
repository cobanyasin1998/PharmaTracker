using Coban.Application.Abstractions.Repositories.Base.Read;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Abstractions.Repositories.Pharmacy;

public interface IPharmacyAsyncReadRepository : IAsyncReadRepository<PharmacyEntity>
{
}
