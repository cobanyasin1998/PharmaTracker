using PharmacyService.Application.BaseRepository.Pharmacy;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.Contexts;
using PharmacyService.Persistence.Repositories.BaseRepositories;

namespace PharmacyService.Persistence.Repositories.Pharmacy;

public class PharmacyReadRepository : ReadRepository<PharmacyEntity>, IPharmacyReadRepository
{
    public PharmacyReadRepository(PharmacyDbContext context) : base(context)
    {

    }
}
