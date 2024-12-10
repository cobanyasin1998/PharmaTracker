using Coban.Application.DataProtection.Abstractions;
using Coban.Application.GeneralExtensions.IQueryableExtensions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetAll;

public class GetAllPharmacyBranchAddressQueryHandler(IDataProtectService _dataProtectService, IUnitOfWork _unitOfWork)
    : IRequestHandler<GetAllPharmacyBranchAddressQueryRequest, IResponse<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyBranchAddressQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<PharmacyBranchAddressEntity>? query = _unitOfWork.PharmacyBranchAddressReadRepository.GetAll(tracking: false);

        List<GetAllPharmacyBranchAddressQueryResponseItemDto> pharmacyBranchAddressList = await query
            .Select(p => new GetAllPharmacyBranchAddressQueryResponseItemDto
            {
                Id = _dataProtectService.Encrypt(p.Id),
                Status = p.Status
            })
            .ApplyPaging(pageNumber: request.Paging.Page, request.Paging.Size)
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync(cancellationToken: cancellationToken);
        return Response<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>.CreateSuccess(new GetAllPharmacyBranchAddressQueryResponse
        {
            TotalCount = totalCount,
            Result = pharmacyBranchAddressList,
            TotalPage = (int)Math.Ceiling((double)totalCount / pharmacyBranchAddressList.Count)
        });
    }
}
