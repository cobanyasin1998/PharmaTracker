using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Delete;


public class DeletePharmacyBranchContactCommandRequest : BaseRequest, IRequest<IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
}
