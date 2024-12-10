using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Delete;
public class DeletePharmacyBranchAddressCommandResponse : BaseResponse
{
    public DeletePharmacyBranchAddressCommandResponse(long Id)
    {
        this.Id = Id;
    }
}
