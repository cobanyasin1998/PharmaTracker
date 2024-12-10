using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class NeighborhoodEntity : BaseEntity
{
    public string Name { get; set; }

    public long DistrictEntityId { get; set; }
    public DistrictEntity DistrictEntity { get; set; }

    public ICollection<StreetEntity> StreetEntities { get; set; }
}
