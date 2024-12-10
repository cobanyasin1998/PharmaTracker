using Coban.Application.DataProtection.Abstractions;
using Coban.Application.GeneralExtensions.IQueryableExtensions;
using Coban.Application.Requests.Filter.Dynamic.Extensions;
using Coban.Application.Requests.Filter.Specification.Extensions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.Pharmacy.Queries.GetAll.Specification.Factory;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll;

public class GetAllPharmacyQueryHandler(IDataProtectService _dataProtectService, IUnitOfWork _unitOfWork) : IRequestHandler<GetAllPharmacyQueryRequest, IResponse<GetAllPharmacyQueryResponse, GeneralErrorDto>>
{

    public async Task<IResponse<GetAllPharmacyQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<PharmacyEntity>? query = _unitOfWork.PharmacyReadRepository.GetAll(tracking: false);

        List<GetAllPharmacyQueryResponseItemDto> pharmacyList = await query
            .ApplySpecification(PharmacySpecificationFactory.GetNameSpecification(request.RequestFilterDto?.Name))
            .ApplySpecification(PharmacySpecificationFactory.GetStatusSpecification(request.RequestFilterDto?.Status))
            .ApplySpecification(PharmacySpecificationFactory.GetLicenseNumberSpecification(request.RequestFilterDto?.LicenseNumber))
            .ApplyFilters(request.Filtering)
           .ApplyOrdering(orderByProperties: request.Sorting)
            .Select(p => new GetAllPharmacyQueryResponseItemDto
            {
                Id = _dataProtectService.Encrypt(p.Id),
                Name = p.Name,
                LicenseNumber = p.LicenseNumber,
                Status = p.Status
            })
            .ApplyOrdering(keySelectors:
            [
                (x => x.Name, true),
                (x => x.LicenseNumber, false)
            ])
            .ApplyPaging(pageNumber: request.Paging.Page, request.Paging.Size)
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync();
        return Response<GetAllPharmacyQueryResponse, GeneralErrorDto>.CreateSuccess(new GetAllPharmacyQueryResponse
        {
            TotalCount = totalCount,
            Result = pharmacyList,
            TotalPage = (int)Math.Ceiling((double)totalCount / pharmacyList.Count)
        });
    }
}
