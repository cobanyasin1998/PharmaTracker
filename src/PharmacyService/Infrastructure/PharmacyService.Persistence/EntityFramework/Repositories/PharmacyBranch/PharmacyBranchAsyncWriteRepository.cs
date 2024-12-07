using Coban.Persistence.Repositories.EntityFramework.Write;
using PharmacyService.Application.Abstractions.Repositories.PharmacyBranch;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.PharmacyBranch;
public class PharmacyBranchAsyncWriteRepository(PharmacyDbContext context) : AsyncWriteRepository<PharmacyBranchEntity, PharmacyDbContext>(context), IPharmacyBranchAsyncWriteRepository
{
}

