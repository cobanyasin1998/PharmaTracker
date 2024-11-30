using Coban.Persistence.Repositories.EntityFramework.Read;
using PharmacyService.Application.Abstractions.Repositories.PharmacyBranch;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.PharmacyBranch;

public class PharmacyBranchAsyncReadRepository : AsyncReadRepository<PharmacyBranchEntity, PharmacyDbContext>, IPharmacyBranchAsyncReadRepository
{
    public PharmacyBranchAsyncReadRepository(PharmacyDbContext context) : base(context)
    {
    }
}
