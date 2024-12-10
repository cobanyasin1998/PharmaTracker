using Coban.Application.Responses;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Delete;


public class DeletePharmacyCommandResponse : BaseResponse
{
    public DeletePharmacyCommandResponse(long Id)
    {
        this.Id = Id;
    }
}
