using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class BuildingEntity : BaseEntity
{
    public string Name { get; set; }
    public string Number { get; set; }

    public long StreetEntityId { get; set; }
    public StreetEntity StreetEntity { get; set; }

    public ICollection<ApartmentEntity> ApartmentEntities { get; set; }
}
