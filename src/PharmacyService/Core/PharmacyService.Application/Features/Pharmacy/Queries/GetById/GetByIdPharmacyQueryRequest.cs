using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryRequest : IRequest<GetByIdPharmacyQueryResponse>
{
    public long Id { get; set; }

}
