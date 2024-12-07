using Coban.Persistence.Repositories.EntityFramework.Read;
using PharmacyService.Application.Abstractions.Repositories.Pharmacy;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;
namespace PharmacyService.Persistence.EntityFramework.Repositories.Pharmacy;

public class PharmacyAsyncReadRepository(PharmacyDbContext context) : AsyncReadRepository<PharmacyEntity, PharmacyDbContext>(context), IPharmacyAsyncReadRepository
{
}



