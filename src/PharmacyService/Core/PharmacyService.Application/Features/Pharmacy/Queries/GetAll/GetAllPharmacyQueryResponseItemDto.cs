using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll;

public class GetAllPharmacyQueryResponseItemDto
{
    public String Id { get; set; } = string.Empty;
    public String Name { get; set; } = string.Empty;
    public String LicenseNumber { get; set; } = string.Empty;
    public EEntityStatus Status { get; set; }
}
