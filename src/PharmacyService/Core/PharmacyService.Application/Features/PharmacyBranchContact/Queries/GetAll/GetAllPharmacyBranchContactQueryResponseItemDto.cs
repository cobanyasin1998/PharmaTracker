using Coban.Domain.Enums.Base;
using PharmacyService.Domain.Enums;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetAll;

public class GetAllPharmacyBranchContactQueryResponseItemDto
{
    public String Id { get; set; }

    public EEntityStatus Status { get; set; }

    public EContactType Type { get; set; }
    public string Value { get; set; }
    public string PharmacyBranchEntityId { get; set; }

}
