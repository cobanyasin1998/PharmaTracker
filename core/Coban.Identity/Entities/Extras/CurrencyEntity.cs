using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class CurrencyEntity : BaseEntity
{
    public string Name { get; set; } // e.g., "Turkish Lira"
    public string Symbol { get; set; } // e.g., "₺"
    public string Code { get; set; } // ISO 4217 code (e.g., "TRY")

    public ICollection<CountryEntity> CountryEntities { get; set; }
}
