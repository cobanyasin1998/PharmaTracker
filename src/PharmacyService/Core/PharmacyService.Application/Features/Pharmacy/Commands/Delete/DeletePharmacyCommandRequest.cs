using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Delete;

public class DeletePharmacyCommandRequest : IRequest<IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>>
{
    public String Id { get; set; }
}
