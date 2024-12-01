using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetAll;

public class GetAllPharmacyBranchQueryResponseItemDto
{
    public String Id { get; set; }

    public EEntityStatus Status { get; set; }
}
