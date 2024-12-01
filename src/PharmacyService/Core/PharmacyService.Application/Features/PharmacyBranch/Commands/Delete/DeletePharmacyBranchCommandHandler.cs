using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Features.PharmacyBranch.Commands.Create;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Delete;

public class DeletePharmacyBranchCommandHandler : IRequestHandler<CreatePharmacyBranchCommandRequest, IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
