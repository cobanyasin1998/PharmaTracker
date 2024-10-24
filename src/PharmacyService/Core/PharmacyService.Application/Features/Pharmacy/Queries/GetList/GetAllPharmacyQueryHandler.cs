using MediatR;
using PharmacyService.Application.BaseRepository.Pharmacy;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetList;

public class GetAllPharmacyQueryHandler : IRequestHandler<GetAllPharmacyQueryRequest, GetAllPharmacyQueryResponse>
{
    private readonly IPharmacyReadRepository _pharmacyReadRepository;

    public GetAllPharmacyQueryHandler(IPharmacyReadRepository pharmacyReadRepository)
    {
        _pharmacyReadRepository = pharmacyReadRepository;
    }

    public async Task<GetAllPharmacyQueryResponse> Handle(GetAllPharmacyQueryRequest request, CancellationToken cancellationToken)
    {
        var query = _pharmacyReadRepository.GetAll(tracking: false);
        var products = query
            //.Paginate(page: request.Page, pageSize: request.Size, orderBy: p => p.CreatedDate, descending: true)
            //.Include(y => y.ProductImageFiles)
            .Select(p => new
            {
                p.Id,
                p.Name,
             //   p.Stock,
              //  p.Price,
                p.CreatedDate,
                p.UpdatedDate,
                //productImageFile = p.ProductImageFiles.FirstOrDefault()
            }).ToList();

        var totalCount = query.Count();

        return new GetAllPharmacyQueryResponse()
        {
            TotalCount = totalCount,
            Products = products
        };
    }
}
