using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Create;

public class CreatePharmacyBranchContactCommandHandler : IRequestHandler<CreatePharmacyBranchContactCommandRequest, IResponse<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchContactCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
