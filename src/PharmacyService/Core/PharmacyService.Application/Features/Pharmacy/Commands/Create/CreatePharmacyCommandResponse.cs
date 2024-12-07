using Coban.Application.Responses;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;


public class CreatePharmacyCommandResponse : BaseResponse
{
    public CreatePharmacyCommandResponse(long Id)
    {
        this.Id = Id;
    }
}

