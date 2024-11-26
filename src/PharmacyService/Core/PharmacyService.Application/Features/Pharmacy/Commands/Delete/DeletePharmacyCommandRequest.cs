using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Delete;

public class DeletePharmacyCommandRequest : IRequest<IResponse<DeletePharmacyCommandResponse, GeneralErrorDTO>>
{
    public String Id { get; set; }
}
