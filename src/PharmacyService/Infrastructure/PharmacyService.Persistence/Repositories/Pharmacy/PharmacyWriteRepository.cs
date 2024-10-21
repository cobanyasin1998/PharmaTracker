using PharmacyService.Application.BaseRepository.Pharmacy;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.Contexts;
using PharmacyService.Persistence.Repositories.BaseRepositories;

namespace PharmacyService.Persistence.Repositories.Pharmacy;

public class PharmacyWriteRepository : WriteRepository<PharmacyEntity>, IPharmacyWriteRepository
{
    public PharmacyWriteRepository(PharmacyDbContext context) : base(context)
    {

    }
}
