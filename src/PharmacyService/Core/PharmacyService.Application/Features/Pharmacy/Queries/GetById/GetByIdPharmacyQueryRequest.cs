using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryRequest :IRequest<IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDTO>>
{
    public String Id { get; set; }
}
