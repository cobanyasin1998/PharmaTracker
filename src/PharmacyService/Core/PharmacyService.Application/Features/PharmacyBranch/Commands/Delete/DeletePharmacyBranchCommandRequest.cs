using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Delete;


public class DeletePharmacyBranchCommandRequest : BaseRequest, IRequest<IResponse<DeletePharmacyBranchCommandResponse, GeneralErrorDto>>
{
}
