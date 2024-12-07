using Coban.Persistence.Repositories.EntityFramework.Write;
using PharmacyService.Application.Abstractions.Repositories.PharmacyBranchContact;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.DbContexts;

namespace PharmacyService.Persistence.EntityFramework.Repositories.PharmacyBranchContact;

public class PharmacyBranchContactAsyncWriteRepository(PharmacyDbContext context) : AsyncWriteRepository<PharmacyBranchContactEntity, PharmacyDbContext>(context), IPharmacyBranchContactAsyncWriteRepository
{
}

