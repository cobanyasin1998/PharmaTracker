using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll.RequestDto;

public class GetAllPharmacyQueryRequestFilterDto
{
    public string Name { get; set; }
    public string LicenseNumber { get; set; }
    public EEntityStatus? Status { get; set; }
}
