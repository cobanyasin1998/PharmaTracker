using Coban.Application.Repositories.Base.Write;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Abstractions.Repositories.PharmacyBranch;

public interface IPharmacyBranchAsyncWriteRepository : IAsyncWriteRepository<PharmacyBranchEntity>
{
}
