using Coban.Application.Requests.Paging.Concretes;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetAll;

public class GetAllPharmacyBranchContactQueryRequest : Paging, IRequest<IResponse<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>>
{
}
