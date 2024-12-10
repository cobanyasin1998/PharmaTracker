using Coban.Application.DataProtection.Abstractions;
using Coban.Application.GeneralExtensions.IQueryableExtensions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetAll;

public class GetAllPharmacyBranchContactQueryHandler(IDataProtectService _dataProtectService, IUnitOfWork _unitOfWork)
    : IRequestHandler<GetAllPharmacyBranchContactQueryRequest, IResponse<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyBranchContactQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<PharmacyBranchContactEntity>? query = _unitOfWork.PharmacyBranchContactReadRepository.GetAll(tracking: false);

        List<GetAllPharmacyBranchContactQueryResponseItemDto> pharmacyBranchContactList = await query
            .Select(p => new GetAllPharmacyBranchContactQueryResponseItemDto
            {
                Id = _dataProtectService.Encrypt(p.Id),
                Status = p.Status
            })
            .ApplyPaging(pageNumber: request.Paging.Page, request.Paging.Size)
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync(cancellationToken: cancellationToken);
        return Response<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>.CreateSuccess(new GetAllPharmacyBranchContactQueryResponse
        {
            TotalCount = totalCount,
            Result = pharmacyBranchContactList,
            TotalPage = (int)Math.Ceiling((double)totalCount / pharmacyBranchContactList.Count)
        });
    }
}
