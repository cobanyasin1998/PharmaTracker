using PharmacyService.Domain.Entities.Common;
using SharedLibrary.Core.Domain.Entities.Common;

namespace PharmacyService.Domain.Entities;

public class PharmacyEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}
