using Coban.Domain.Entities.Base;

namespace PharmacyService.Domain.Entities;

public class PharmacyBranchAddressEntity : BaseEntity
{
    public bool IsPrimary { get; set; }
    public string Address { get; set; }
    public long? ProvinceId { get; set; }
    public long? DistrictId { get; set; }
    public long? NeighbourhoodId { get; set; }
    public long? StreetId { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    public long PharmacyBranchEntityId { get; set; }
    public PharmacyBranchEntity PharmacyBranchEntity { get; set; }
}
