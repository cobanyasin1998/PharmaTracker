using Coban.Application.Responses;
using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryResponse : BaseResponse
{
    public String Name { get; set; } = string.Empty;
    public String Description { get; set; } = string.Empty;
    public String LicenseNumber { get; set; } = string.Empty;
    public EEntityStatus Status { get; set; }
}