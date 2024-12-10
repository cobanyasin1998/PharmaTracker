using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class GeoLocationEntity: BaseEntity
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public long AddressEntityId { get; set; }
    public AddressEntity AddressEntity { get; set; }
}
