using Coban.Domain.Entities.Base;

namespace PharmacyService.Domain.Entities;

public class PharmacyEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string LicenseNumber { get; set; }
    public ICollection<PharmacyBranchEntity> PharmacyBranchEntities { get; set; }
}
