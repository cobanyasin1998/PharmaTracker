using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Update;

public class UpdatePharmacyBranchContactCommandResponse : BaseResponse
{
    public UpdatePharmacyBranchContactCommandResponse(long Id)
    {
        this.Id = Id;
    }
}