using Coban.Application.Requests.Paging.Concretes;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetAll;

public class GetAllPharmacyBranchAddressQueryRequest : Paging, IRequest<IResponse<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{
}
