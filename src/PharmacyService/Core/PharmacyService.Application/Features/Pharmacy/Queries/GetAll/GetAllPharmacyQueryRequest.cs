using Coban.Application.Requests.Base;
using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;
using Coban.Application.Requests.OrderBy.Dto;
using Coban.Application.Requests.Paging.Concretes;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Features.Pharmacy.Queries.GetAll.RequestDto;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll;

public class GetAllPharmacyQueryRequest(
    Paging paging,
    IEnumerable<FilterGroup>? filtering = null,
    IEnumerable<Sorting>? sorting = null,
    GetAllPharmacyQueryRequestFilterDto? requestFilterDto = null) : FullRequestDto(paging, filtering, sorting), IRequest<IResponse<GetAllPharmacyQueryResponse, GeneralErrorDto>>
{
    public GetAllPharmacyQueryRequestFilterDto? RequestFilterDto { get; set; } = requestFilterDto;
}
