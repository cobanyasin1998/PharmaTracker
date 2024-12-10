using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranch.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;

public class GetByIdPharmacyBranchAddressQueryHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    : IRequestHandler<GetByIdPharmacyBranchAddressQueryRequest, IResponse<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyBranchAddressQueryRequest request, CancellationToken cancellationToken)
    {
        PharmacyBranchAddressEntity? pharmacyBranchAddressEntity = await _unitOfWork.PharmacyBranchAddressReadRepository.GetByIdAsync(request.Id, tracking: false, cancellationToken: cancellationToken);

        if (pharmacyBranchAddressEntity is null)
            return Response<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyBranchConstants.NotFound, ""));

        GetByIdPharmacyBranchAddressQueryResponse getByIdPharmacyBranchAddressQueryResponse = _mapper.Map<GetByIdPharmacyBranchAddressQueryResponse>(pharmacyBranchAddressEntity);

        return Response<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>.CreateSuccess(getByIdPharmacyBranchAddressQueryResponse);
    }
}
