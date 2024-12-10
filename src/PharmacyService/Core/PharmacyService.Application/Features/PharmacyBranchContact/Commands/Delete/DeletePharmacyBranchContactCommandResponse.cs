using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Delete;


public class DeletePharmacyBranchContactCommandResponse : BaseResponse
{
    public DeletePharmacyBranchContactCommandResponse(long Id)
    {
        this.Id = Id;
    }
}
