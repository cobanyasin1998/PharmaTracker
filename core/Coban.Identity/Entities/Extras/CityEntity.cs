using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class CityEntity : BaseEntity
{
    public string Name { get; set; }

    public long RegionEntityId { get; set; }
    public RegionEntity RegionEntity { get; set; }

    public ICollection<DistrictEntity> DistrictEntities { get; set; }
}
