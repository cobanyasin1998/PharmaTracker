using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Create;
public class CreatePharmacyBranchContactCommandResponse : BaseResponse
{
    public CreatePharmacyBranchContactCommandResponse(long Id)
    {
        this.Id = Id;
    }
}

