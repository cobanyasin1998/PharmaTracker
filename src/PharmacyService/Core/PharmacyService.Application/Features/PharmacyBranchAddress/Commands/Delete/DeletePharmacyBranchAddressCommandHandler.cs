using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Delete;

public class DeletePharmacyBranchAddressCommandHandler : IRequestHandler<CreatePharmacyBranchAddressCommandRequest, IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchAddressCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
