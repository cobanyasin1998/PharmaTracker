using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Extras;

public class AddressEntity : BaseEntity
{
    public string FullAddress { get; set; }
    public long ApartmentId { get; set; }
    public ApartmentEntity ApartmentEntity { get; set; }

    public GeoLocationEntity GeoLocationEntity { get; set; }
}
