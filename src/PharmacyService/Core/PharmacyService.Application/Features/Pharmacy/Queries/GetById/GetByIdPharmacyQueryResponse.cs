using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryResponse
{
    public String Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LicenseNumber { get; set; }
    public EEntityStatus Status { get; set; }
}
