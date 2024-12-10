using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class RegionEntity : BaseEntity
{
    public string Name { get; set; }

    public long CountryEntityId { get; set; }
    public CountryEntity CountryEntity { get; set; }

    public ICollection<CityEntity> CityEntities { get; set; }
}
