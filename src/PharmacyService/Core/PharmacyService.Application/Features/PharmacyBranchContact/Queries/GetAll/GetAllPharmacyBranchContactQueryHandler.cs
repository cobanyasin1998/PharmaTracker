using Coban.Application.GeneralExtensions.IQueryableExtensions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetAll;

public class GetAllPharmacyBranchContactQueryHandler : IRequestHandler<GetAllPharmacyBranchContactQueryRequest, IResponse<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPharmacyBranchContactQueryHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyBranchContactQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<PharmacyBranchContactEntity>? query = _unitOfWork.PharmacyBranchContactReadRepository.GetAll(tracking: false);


        List<GetAllPharmacyBranchContactQueryResponseItemDto> pharmacyList = await query
            .Select(p => new GetAllPharmacyBranchContactQueryResponseItemDto
            {
                Id = _dataProtectService.Encrypt(p.Id),
               
                Status = p.Status
            })
            
            .ApplyPaging(pageNumber: request.Page, request.Size)
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync();
        int totalPage = (int)Math.Ceiling((double)totalCount / pharmacyList.Count);
        return Response<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>.CreateSuccess(new GetAllPharmacyBranchContactQueryResponse
        {
            TotalCount = totalCount,
            Result = pharmacyList,
            ResultCount = pharmacyList.Count,
            TotalPage = totalPage,
            Next = request.Page < totalPage,
            Previous = request.Page > 1,
            Next3Page = request.Page + 3 < totalPage,
            Previous3Page = request.Page - 3 > 1
        });
    }
}
