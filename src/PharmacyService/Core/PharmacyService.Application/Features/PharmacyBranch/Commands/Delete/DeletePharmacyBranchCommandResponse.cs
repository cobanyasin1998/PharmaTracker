using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Delete;
public class DeletePharmacyBranchCommandResponse : BaseResponse
{
    public DeletePharmacyBranchCommandResponse(long Id)
    {
        this.Id = Id;
    }
}
