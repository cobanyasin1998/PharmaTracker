using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class StreetEntity : BaseEntity
{
    public string Name { get; set; }

    public long NeighborhoodEntityId { get; set; }
    public NeighborhoodEntity NeighborhoodEntity { get; set; }

    public ICollection<BuildingEntity> BuildingEntities { get; set; }
}
