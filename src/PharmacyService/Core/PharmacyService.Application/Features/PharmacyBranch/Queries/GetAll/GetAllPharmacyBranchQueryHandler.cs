using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        var query = _unitOfWork.PharmacyBranchReadRepository.GetAll(tracking: false);


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
            ResultCount = pharmacyList.Count,
            TotalPage = totalPage,
            Next = request.Page < totalPage,
            Previous = request.Page > 1,
            Next3Page = request.Page + 3 < totalPage,
            Previous3Page = request.Page - 3 > 1
        });
    }
}
