using Coban.Persistence.Repositories.EntityFramework.Read;
using PharmacyService.Application.Abstractions.Repositories.PharmacyBranchAddress;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.PharmacyBranchAddress;

public class PharmacyBranchAddressAsyncReadRepository(PharmacyDbContext context) : AsyncReadRepository<PharmacyBranchAddressEntity, PharmacyDbContext>(context), IPharmacyBranchAddressAsyncReadRepository
{
}
