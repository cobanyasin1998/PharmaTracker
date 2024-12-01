using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;

public class CreatePharmacyBranchAddressCommandHandler : IRequestHandler<CreatePharmacyBranchAddressCommandRequest, IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchAddressCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
