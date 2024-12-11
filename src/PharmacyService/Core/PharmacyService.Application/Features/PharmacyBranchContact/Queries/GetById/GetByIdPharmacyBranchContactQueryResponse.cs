using Coban.Application.Responses;
using Coban.Domain.Enums.Base;
using PharmacyService.Domain.Enums;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetById;

public class GetByIdPharmacyBranchContactQueryResponse : BaseResponse
{
    public String Id { get; set; }

    public EEntityStatus Status { get; set; }

    public EContactType Type { get; set; }
    public string Value { get; set; }
    public string PharmacyBranchEntityId { get; set; }


}
