using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Update;


public class UpdatePharmacyBranchCommandResponse : BaseResponse
{
    public UpdatePharmacyBranchCommandResponse(long Id)
    {
        this.Id = Id;
    }
}