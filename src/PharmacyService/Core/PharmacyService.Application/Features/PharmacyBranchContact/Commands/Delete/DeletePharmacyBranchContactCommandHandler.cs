using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Delete;

public class DeletePharmacyBranchContactCommandHandler : IRequestHandler<DeletePharmacyBranchContactCommandRequest, IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyBranchContactCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
