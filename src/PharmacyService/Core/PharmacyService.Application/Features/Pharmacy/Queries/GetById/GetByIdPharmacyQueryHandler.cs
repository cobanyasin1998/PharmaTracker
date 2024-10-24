using MediatR;
using PharmacyService.Application.BaseRepository.Pharmacy;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryHandler : IRequestHandler<GetByIdPharmacyQueryRequest, GetByIdPharmacyQueryResponse>
{
    private readonly IPharmacyReadRepository _pharmacyReadRepository;

    public GetByIdPharmacyQueryHandler(IPharmacyReadRepository pharmacyReadRepository)
    {
        _pharmacyReadRepository = pharmacyReadRepository;
    }

    public async Task<GetByIdPharmacyQueryResponse> Handle(GetByIdPharmacyQueryRequest request, CancellationToken cancellationToken)
    {
        PharmacyEntity pharmacyEntity = await _pharmacyReadRepository.GetByIdAsync(request.Id, tracking: false);
        return new GetByIdPharmacyQueryResponse()
        {
          
            Name = pharmacyEntity.Name,
            Description = pharmacyEntity.Description
          
        };
    }
}
