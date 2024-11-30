using Coban.Persistence.Repositories.EntityFramework.Write;
using PharmacyService.Application.Abstractions.Repositories.PharmacyBranchContact;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.PharmacyBranchContact;

public class PharmacyBranchContactAsyncWriteRepository : AsyncWriteRepository<PharmacyBranchContactEntity, PharmacyDbContext>, IPharmacyBranchContactAsyncWriteRepository
{
    public PharmacyBranchContactAsyncWriteRepository(PharmacyDbContext context) : base(context)
    {
    }
}

