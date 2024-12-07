using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll;

public class GetAllPharmacyQueryResponseItemDto
{
    public String Id { get; set; } 
    public String Name { get; set; } 
    public String LicenseNumber { get; set; } 
    public EEntityStatus Status { get; set; }
}
