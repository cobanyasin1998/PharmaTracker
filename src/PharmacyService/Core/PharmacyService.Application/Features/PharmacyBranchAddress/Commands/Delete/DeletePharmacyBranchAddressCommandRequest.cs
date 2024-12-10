using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Delete;


public class DeletePharmacyBranchAddressCommandRequest : BaseRequest, IRequest<IResponse<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
}
