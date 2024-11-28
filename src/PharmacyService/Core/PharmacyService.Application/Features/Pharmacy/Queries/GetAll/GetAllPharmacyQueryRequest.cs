using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;
using Coban.Application.Requests.OrderBy.Dto;
using Coban.Application.Requests.Paging.Concretes;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Features.Pharmacy.Queries.GetAll.RequestDto;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll;

public class GetAllPharmacyQueryRequest : Paging, IRequest<IResponse<GetAllPharmacyQueryResponse, GeneralErrorDto>>
{
    public List<FilterGroup>? CustomFilters { get; set; }
    public List<Sorting>? CustomSorting { get; set; }

    public GetAllPharmacyQueryRequestFilterDto? RequestFilterDto { get; set; }
}
