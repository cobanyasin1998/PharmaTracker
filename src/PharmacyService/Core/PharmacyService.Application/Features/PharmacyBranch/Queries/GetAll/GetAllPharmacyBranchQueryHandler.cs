using Coban.Application.GeneralExtensions.IQueryableExtensions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetAll;

public class GetAllPharmacyBranchQueryHandler : IRequestHandler<GetAllPharmacyBranchQueryRequest, IResponse<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPharmacyBranchQueryHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyBranchQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<PharmacyBranchEntity?> query = _unitOfWork.PharmacyBranchReadRepository.GetAll(tracking: false);


        List<GetAllPharmacyBranchQueryResponseItemDto> pharmacyList = await query         
            .Select(p => new GetAllPharmacyBranchQueryResponseItemDto
            {
                Id = _dataProtectService.Encrypt(p.Id),
                Status = p.Status
            })
            
            .ApplyPaging(pageNumber: request.Page, request.Size)
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync();
        int totalPage = (int)Math.Ceiling((double)totalCount / pharmacyList.Count);
        return Response<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>.CreateSuccess(new GetAllPharmacyBranchQueryResponse
        {
            TotalCount = totalCount,
            Result = pharmacyList,
            TotalPage = totalPage,
          
        });
    }
}
