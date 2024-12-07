using Coban.Persistence.Repositories.EntityFramework.Read;
using PharmacyService.Application.Abstractions.Repositories.PharmacyBranch;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.PharmacyBranch;

public class PharmacyBranchAsyncReadRepository(PharmacyDbContext context) : AsyncReadRepository<PharmacyBranchEntity, PharmacyDbContext>(context), IPharmacyBranchAsyncReadRepository
{
}
