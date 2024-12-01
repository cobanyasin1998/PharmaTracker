using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Update;

public class UpdatePharmacyBranchContactCommandHandler : IRequestHandler<UpdatePharmacyBranchContactCommandRequest, IResponse<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyBranchContactCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
