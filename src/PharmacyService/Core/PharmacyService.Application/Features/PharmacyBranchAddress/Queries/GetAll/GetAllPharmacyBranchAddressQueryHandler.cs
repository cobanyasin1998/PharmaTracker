using Coban.Application.GeneralExtensions.IQueryableExtensions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetAll;

public class GetAllPharmacyBranchAddressQueryHandler : IRequestHandler<GetAllPharmacyBranchAddressQueryRequest, IResponse<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPharmacyBranchAddressQueryHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyBranchAddressQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<PharmacyBranchAddressEntity>? query = _unitOfWork.PharmacyBranchAddressReadRepository.GetAll(tracking: false);


        List<GetAllPharmacyBranchAddressQueryResponseItemDto> pharmacyBranchAddressList = await query
            
            .Select(p => new GetAllPharmacyBranchAddressQueryResponseItemDto
            {
                Id = _dataProtectService.Encrypt(p.Id),
              
                Status = p.Status
            })            
            .ApplyPaging(pageNumber: request.Page, request.Size)
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync();
        int totalPage = (int)Math.Ceiling((double)totalCount / pharmacyBranchAddressList.Count);
        return Response<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>.CreateSuccess(new GetAllPharmacyBranchAddressQueryResponse
        {
            TotalCount = totalCount,
            Result = pharmacyBranchAddressList,
            TotalPage = totalPage,
           
        });
    }
}
