using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Delete;

public class DeletePharmacyCommandRequest : BaseRequest, IRequest<IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>>
{
}
