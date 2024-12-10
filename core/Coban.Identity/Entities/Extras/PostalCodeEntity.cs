using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class PostalCodeEntity : BaseEntity
{
    public string Code { get; set; }

    public long DistrictEntityId { get; set; }
    public DistrictEntity DistrictEntity { get; set; }
}
