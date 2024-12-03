using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryHandler : IRequestHandler<GetByIdPharmacyQueryRequest, IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdPharmacyQueryHandler(IMapper mapper, IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyQueryRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);
        PharmacyEntity? pharmacyEntity = await _unitOfWork.PharmacyReadRepository.GetByIdAsync(id, tracking: false, cancellationToken: cancellationToken);
        GetByIdPharmacyQueryResponse dto = _mapper.Map<PharmacyEntity, GetByIdPharmacyQueryResponse>(pharmacyEntity);

        return Response<GetByIdPharmacyQueryResponse, GeneralErrorDto>.CreateSuccess(dto);
    }
}
