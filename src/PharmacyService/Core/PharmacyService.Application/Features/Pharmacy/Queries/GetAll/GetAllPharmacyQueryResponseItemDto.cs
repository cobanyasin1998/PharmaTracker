using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll;

public class GetAllPharmacyQueryResponseItemDto
{
    public String Id { get; set; } = null!;
    public String Name { get; set; } = null!;
    public String LicenseNumber { get; set; } = null!;
    public EEntityStatus Status { get; set; }
}
