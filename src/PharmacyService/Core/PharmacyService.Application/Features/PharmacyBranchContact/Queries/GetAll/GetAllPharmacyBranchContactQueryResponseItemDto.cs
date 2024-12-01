using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetAll;

public class GetAllPharmacyBranchContactQueryResponseItemDto
{
    public String Id { get; set; }

    public EEntityStatus Status { get; set; }
}
