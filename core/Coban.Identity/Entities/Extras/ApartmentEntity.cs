using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class ApartmentEntity : BaseEntity
{
    public string Name { get; set; } // e.g., "Daire 5"

    public long BuildingEntityId { get; set; }
    public BuildingEntity BuildingEntity { get; set; }

    public ICollection<AddressEntity> AddressEntities { get; set; }
}
