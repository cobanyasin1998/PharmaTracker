using Coban.Application.Requests.Decrypt;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryRequest : GetByIdQueryRequestBase, IRequest<IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>>
{
  
}

