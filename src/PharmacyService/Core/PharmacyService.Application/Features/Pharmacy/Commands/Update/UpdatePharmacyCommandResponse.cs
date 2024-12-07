using Coban.Application.Responses;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandResponse : BaseResponse
{
    public UpdatePharmacyCommandResponse(long Id)
    {
        this.Id = Id;
    }
}