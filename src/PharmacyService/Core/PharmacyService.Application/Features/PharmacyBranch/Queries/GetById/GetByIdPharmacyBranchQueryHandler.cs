using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranch.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetById;

public class GetByIdPharmacyBranchQueryHandler(IMapper _mapper, IUnitOfWork _unitOfWork)
    : IRequestHandler<GetByIdPharmacyBranchQueryRequest, IResponse<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyBranchQueryRequest request, CancellationToken cancellationToken)
    {
        PharmacyBranchEntity? pharmacyBranchEntity = await _unitOfWork.PharmacyBranchReadRepository.GetByIdAsync(request.Id, tracking: false, cancellationToken: cancellationToken);

        if (pharmacyBranchEntity is null)
            return Response<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyBranchConstants.NotFound, ""));

        GetByIdPharmacyBranchQueryResponse getByIdPharmacyQueryResponse = _mapper.Map<GetByIdPharmacyBranchQueryResponse>(pharmacyBranchEntity);

        return Response<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>.CreateSuccess(getByIdPharmacyQueryResponse);
    }
}
