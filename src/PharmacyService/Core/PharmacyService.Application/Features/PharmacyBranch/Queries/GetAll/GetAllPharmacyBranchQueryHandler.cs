using Coban.Application.DataProtection.Abstractions;
using Coban.Application.GeneralExtensions.IQueryableExtensions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetAll;

public class GetAllPharmacyBranchQueryHandler(IDataProtectService _dataProtectService, IUnitOfWork _unitOfWork) 
    : IRequestHandler<GetAllPharmacyBranchQueryRequest, IResponse<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyBranchQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<PharmacyBranchEntity>? query = _unitOfWork.PharmacyBranchReadRepository.GetAll(tracking: false);

        List<GetAllPharmacyBranchQueryResponseItemDto> pharmacyBranchList = await query
            .Select(p => new GetAllPharmacyBranchQueryResponseItemDto
            {
                Id = _dataProtectService.Encrypt(p.Id),
                Name = p.Name,
                Status = p.Status
            })
            .ApplyPaging(pageNumber: request.Paging.Page, request.Paging.Size)
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync(cancellationToken: cancellationToken);
        return Response<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>.CreateSuccess(new GetAllPharmacyBranchQueryResponse
        {
            TotalCount = totalCount,
            Result = pharmacyBranchList,
            TotalPage = (int)Math.Ceiling((double)totalCount / pharmacyBranchList.Count)
        });
    }
}
