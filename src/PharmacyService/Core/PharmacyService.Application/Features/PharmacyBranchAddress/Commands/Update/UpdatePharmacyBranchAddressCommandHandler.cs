using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;

public class UpdatePharmacyBranchAddressCommandHandler : IRequestHandler<UpdatePharmacyBranchAddressCommandRequest, IResponse<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyBranchAddressCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
