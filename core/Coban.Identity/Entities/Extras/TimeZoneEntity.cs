using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class TimeZoneEntity : BaseEntity
{
    public string Name { get; set; }
    public string UtcOffset { get; set; }

    public long CountryEntityId { get; set; }
    public CountryEntity CountryEntity { get; set; }
}
