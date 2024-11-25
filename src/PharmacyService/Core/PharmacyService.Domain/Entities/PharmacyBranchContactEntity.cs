using Coban.Domain.Entities.Base;
using PharmacyService.Domain.Enums;

namespace PharmacyService.Domain.Entities;

public class PharmacyBranchContactEntity : BaseEntity
{
    public EContactType ContactType { get; set; }
    public string Value { get; set; }
    public long PharmacyBranchEntityId { get; set; }
    public PharmacyBranchEntity PharmacyBranchEntity { get; set; }
}
