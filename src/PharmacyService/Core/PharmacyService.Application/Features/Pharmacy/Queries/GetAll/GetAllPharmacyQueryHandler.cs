using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll;

public class GetAllPharmacyQueryHandler : IRequestHandler<GetAllPharmacyQueryRequest, IResponse<GetAllPharmacyQueryResponse, GeneralErrorDTO>>
{ 

    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPharmacyQueryHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<GetAllPharmacyQueryResponse, GeneralErrorDTO>> Handle(GetAllPharmacyQueryRequest request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.AsyncPharmacyReadRepository.GetAll(tracking:false);

        List<GetAllPharmacyQueryResponseItemDto> pharmacyList = await query
            .Select(p => new GetAllPharmacyQueryResponseItemDto
            {
                Id = _dataProtectService.Encrypt(p.Id),
                Name = p.Name,
                LicenseNumber = p.LicenseNumber,
                Status = p.Status
            })
            //.ApplyPagingAndOrdering(
            //    pageNumber: request.Page,
            //    pageSize: request.Size,
            //    keySelectors: new List<(Expression<Func<GetAllPharmacyQueryResponseItemDto, object>>, bool)>
            //    {
            //        (x => x.Name, true),
            //        (x => x.LicenseNumber, false)
            //    })
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync();

        return Response<GetAllPharmacyQueryResponse,GeneralErrorDTO>.CreateSuccess(new GetAllPharmacyQueryResponse
        {
            TotalCount = totalCount,
            Result = pharmacyList
        });

    }
}
