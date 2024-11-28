using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryRequest :IRequest<IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>>
{
    public String Id { get; set; }
}
