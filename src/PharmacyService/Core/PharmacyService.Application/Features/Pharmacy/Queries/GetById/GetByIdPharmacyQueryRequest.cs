using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryRequest : BaseRequest, IRequest<IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>>
{


}

