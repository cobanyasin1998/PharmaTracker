using Coban.Persistence.Repositories.EntityFramework.Read;
using PharmacyService.Application.Abstractions.Repositories.PharmacyBranchAddress;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.PharmacyBranchAddress;

public class PharmacyBranchAddressAsyncReadRepository : AsyncReadRepository<PharmacyBranchAddressEntity, PharmacyDbContext>, IPharmacyBranchAddressAsyncReadRepository
{
    public PharmacyBranchAddressAsyncReadRepository(PharmacyDbContext context) : base(context)
    {
    }
}
