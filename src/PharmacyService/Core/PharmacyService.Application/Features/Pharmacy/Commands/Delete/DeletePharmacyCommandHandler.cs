using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Delete;

public class DeletePharmacyCommandHandler : IRequestHandler<DeletePharmacyCommandRequest, IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>>
{
    public Task<IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>> Handle(DeletePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
