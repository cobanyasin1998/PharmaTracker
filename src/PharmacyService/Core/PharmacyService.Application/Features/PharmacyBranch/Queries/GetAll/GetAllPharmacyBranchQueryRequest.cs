using Coban.Application.Requests.Base;
using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;
using Coban.Application.Requests.OrderBy.Dto;
using Coban.Application.Requests.Paging.Concretes;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetAll;

public class GetAllPharmacyBranchQueryRequest : FullRequestDto, IRequest<IResponse<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>>
{
    public GetAllPharmacyBranchQueryRequest(Paging paging, IEnumerable<FilterGroup> filtering = null, IEnumerable<Sorting> sorting = null) : base(paging, filtering, sorting)
    {
    }
}
