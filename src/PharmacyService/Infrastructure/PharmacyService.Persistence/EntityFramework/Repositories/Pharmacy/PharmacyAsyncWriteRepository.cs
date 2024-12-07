using Coban.Persistence.Repositories.EntityFramework.Write;
using PharmacyService.Application.Abstractions.Repositories.Pharmacy;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.Pharmacy;

public class PharmacyAsyncWriteRepository(PharmacyDbContext context) : AsyncWriteRepository<PharmacyEntity, PharmacyDbContext>(context), IPharmacyAsyncWriteRepository
{
}

