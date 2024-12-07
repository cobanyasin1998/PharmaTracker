using Coban.Persistence.Repositories.EntityFramework.Read;
using PharmacyService.Application.Abstractions.Repositories.PharmacyBranchContact;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.PharmacyBranchContact;

public class PharmacyBranchContactAsyncReadRepository(PharmacyDbContext context) : AsyncReadRepository<PharmacyBranchContactEntity, PharmacyDbContext>(context), IPharmacyBranchContactAsyncReadRepository
{
}



