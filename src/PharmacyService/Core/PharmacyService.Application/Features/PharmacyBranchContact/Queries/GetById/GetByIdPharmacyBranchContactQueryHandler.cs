using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetById;

public class GetByIdPharmacyBranchContactQueryHandler : IRequestHandler<GetByIdPharmacyBranchContactQueryRequest, IResponse<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdPharmacyBranchContactQueryHandler(IMapper mapper, IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyBranchContactQueryRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);
        PharmacyBranchContactEntity? pharmacyBranchContactEntity = await _unitOfWork.PharmacyBranchContactReadRepository.GetByIdAsync(id, tracking: false, cancellationToken: cancellationToken);
        GetByIdPharmacyBranchContactQueryResponse dto = _mapper.Map<PharmacyBranchContactEntity, GetByIdPharmacyBranchContactQueryResponse>(pharmacyBranchContactEntity);

        return Response<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>.CreateSuccess(dto);
    }
}
