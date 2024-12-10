using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class DistrictEntity: BaseEntity
{
    public string Name { get; set; }

    public long CityEntityId { get; set; }
    public CityEntity CityEntity { get; set; }

    public ICollection<NeighborhoodEntity> NeighborhoodEntities { get; set; }
}
