using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranch.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetById;

public class GetByIdPharmacyBranchContactQueryHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    : IRequestHandler<GetByIdPharmacyBranchContactQueryRequest, IResponse<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyBranchContactQueryRequest request, CancellationToken cancellationToken)
    {
        PharmacyBranchContactEntity? pharmacyBranchContactEntity = await _unitOfWork.PharmacyBranchContactReadRepository.GetByIdAsync(request.Id, tracking: false, cancellationToken: cancellationToken);

        if (pharmacyBranchContactEntity is null)
            return Response<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyBranchConstants.NotFound, ""));

        GetByIdPharmacyBranchContactQueryResponse getByIdPharmacyBranchContactQueryResponse = _mapper.Map<GetByIdPharmacyBranchContactQueryResponse>(pharmacyBranchContactEntity);

        return Response<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>.CreateSuccess(getByIdPharmacyBranchContactQueryResponse);
    }
}
