using Coban.Application.Requests.Paging.Concretes;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetAll;

public class GetAllPharmacyBranchQueryRequest : Paging, IRequest<IResponse<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>>
{
}
