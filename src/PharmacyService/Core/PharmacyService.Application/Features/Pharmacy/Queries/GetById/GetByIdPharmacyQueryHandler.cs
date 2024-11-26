using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryHandler : IRequestHandler<GetByIdPharmacyQueryRequest, IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDTO>>
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

    public async Task<IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDTO>> Handle(GetByIdPharmacyQueryRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);
        PharmacyEntity? pharmacyEntity = await _unitOfWork.AsyncPharmacyReadRepository.GetByIdAsync(id, tracking: false, cancellationToken: cancellationToken);
        var dto = _mapper.Map<PharmacyEntity, GetByIdPharmacyQueryResponse>(pharmacyEntity);

        return Response<GetByIdPharmacyQueryResponse, GeneralErrorDTO>.CreateSuccess(dto);
    }
}
