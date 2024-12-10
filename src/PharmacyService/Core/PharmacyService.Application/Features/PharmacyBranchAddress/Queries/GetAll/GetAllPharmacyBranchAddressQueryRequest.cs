using Coban.Application.Requests.Base;
using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;
using Coban.Application.Requests.OrderBy.Dto;
using Coban.Application.Requests.Paging.Concretes;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetAll;

public class GetAllPharmacyBranchAddressQueryRequest(Paging paging, IEnumerable<FilterGroup>? filtering = null, IEnumerable<Sorting>? sorting = null)
    : FullRequestDto(paging, filtering, sorting), IRequest<IResponse<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{
}
