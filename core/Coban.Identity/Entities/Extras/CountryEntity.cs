using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class CountryEntity : BaseEntity
{
    public string Name { get; set; }
    public string IsoCode { get; set; } // ISO 3166-1 alpha-2 (e.g., "TR" for Turkey)
    public string PhoneCode { get; set; } // e.g., "+90"
    public string FlagUrl { get; set; } // Optional flag image URL

    public long CurrencyEntityId { get; set; }
    public CurrencyEntity CurrencyEntity { get; set; }

    public ICollection<RegionEntity> RegionEntity { get; set; }
    public ICollection<TimeZoneEntity> TimeZoneEntities { get; set; }
}
