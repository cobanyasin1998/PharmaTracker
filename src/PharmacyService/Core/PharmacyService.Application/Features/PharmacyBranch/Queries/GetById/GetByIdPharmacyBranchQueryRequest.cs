using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetById;

public class GetByIdPharmacyBranchQueryRequest : BaseRequest, IRequest<IResponse<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>>
{
}