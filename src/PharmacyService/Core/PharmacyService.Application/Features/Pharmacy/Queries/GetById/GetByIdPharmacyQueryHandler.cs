using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.Pharmacy.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryHandler(IMapper _mapper, IUnitOfWork _unitOfWork) 
    : IRequestHandler<GetByIdPharmacyQueryRequest, IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>>
{
    public async Task<IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyQueryRequest request, CancellationToken cancellationToken)
    {
        PharmacyEntity? pharmacyEntity = await _unitOfWork.PharmacyReadRepository.GetByIdAsync(request.Id, tracking: false, cancellationToken: cancellationToken);

        if (pharmacyEntity is null)
            return Response<GetByIdPharmacyQueryResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyConstants.NotFound, ""));

        GetByIdPharmacyQueryResponse getByIdPharmacyQueryResponse = _mapper.Map<GetByIdPharmacyQueryResponse>(pharmacyEntity);

        return Response<GetByIdPharmacyQueryResponse, GeneralErrorDto>.CreateSuccess(getByIdPharmacyQueryResponse);
    }
}
