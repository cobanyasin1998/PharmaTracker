using Coban.Persistence.Repositories.EntityFramework.Write;
using PharmacyService.Application.Abstractions.Repositories.PharmacyBranchAddress;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.PharmacyBranchAddress;
public class PharmacyBranchAddressAsyncWriteRepository : AsyncWriteRepository<PharmacyBranchAddressEntity, PharmacyDbContext>, IPharmacyBranchAddressAsyncWriteRepository
{
    public PharmacyBranchAddressAsyncWriteRepository(PharmacyDbContext context) : base(context)
    {
    }
}

