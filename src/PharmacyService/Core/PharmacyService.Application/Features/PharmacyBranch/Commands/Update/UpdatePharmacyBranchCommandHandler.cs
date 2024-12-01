using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Update;

public class UpdatePharmacyBranchCommandHandler : IRequestHandler<UpdatePharmacyBranchCommandRequest, IResponse<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyBranchCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
