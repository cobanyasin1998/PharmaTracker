using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetAll;

public class GetAllPharmacyBranchAddressQueryResponseItemDto
{
    public String Id { get; set; }

    public EEntityStatus Status { get; set; }
}
