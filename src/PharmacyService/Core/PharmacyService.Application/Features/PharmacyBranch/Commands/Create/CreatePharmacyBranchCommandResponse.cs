using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Create;

public class CreatePharmacyBranchCommandResponse : BaseResponse
{
    public CreatePharmacyBranchCommandResponse(long Id)
    {
        this.Id = Id;
    }
}

