using Coban.Application.Requests.Paging.Concretes;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll;

public class GetAllPharmacyQueryRequest : Paging, IRequest<IResponse<GetAllPharmacyQueryResponse, GeneralErrorDTO>>
{
}
