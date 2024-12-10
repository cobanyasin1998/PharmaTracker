using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;
public class CreatePharmacyBranchAddressCommandResponse : BaseResponse
{
    public CreatePharmacyBranchAddressCommandResponse(long Id)
    {
        this.Id = Id;
    }
}

