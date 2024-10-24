using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetList;

public class GetAllPharmacyQueryRequest : IRequest<GetAllPharmacyQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
