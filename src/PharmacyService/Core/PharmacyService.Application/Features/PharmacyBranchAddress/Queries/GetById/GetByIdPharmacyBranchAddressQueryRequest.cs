using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;

public class GetByIdPharmacyBranchAddressQueryRequest : BaseRequest, IRequest<IResponse<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{

}
