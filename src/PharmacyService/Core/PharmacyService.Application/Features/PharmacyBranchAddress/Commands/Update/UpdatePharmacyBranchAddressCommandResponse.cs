using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;

public class UpdatePharmacyBranchAddressCommandResponse : BaseResponse
{
    public UpdatePharmacyBranchAddressCommandResponse(long Id)
    {
        this.Id = Id;
    }
}