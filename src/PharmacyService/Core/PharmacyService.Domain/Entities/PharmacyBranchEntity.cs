using Coban.Domain.Entities.Base;

namespace PharmacyService.Domain.Entities;

public class PharmacyBranchEntity : BaseEntity
{
    public string BranchName { get; set; }
    public long PharmacyEntityId { get; set; }
    public PharmacyEntity PharmacyEntity { get; set; }

    public ICollection<PharmacyBranchAddressEntity> PharmacyBranchAddressEntities { get; set; }
    public ICollection<PharmacyBranchContactEntity> PharmacyBranchContactEntities { get; set; }

}
