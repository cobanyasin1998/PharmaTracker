using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetById;

public class GetByIdPharmacyBranchQueryHandler : IRequestHandler<GetByIdPharmacyBranchQueryRequest, IResponse<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdPharmacyBranchQueryHandler(IMapper mapper, IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyBranchQueryRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);
        PharmacyBranchEntity? pharmacyBranchEntity = await _unitOfWork.PharmacyBranchReadRepository.GetByIdAsync(id, tracking: false, cancellationToken: cancellationToken);
        GetByIdPharmacyBranchQueryResponse dto = _mapper.Map<PharmacyBranchEntity, GetByIdPharmacyBranchQueryResponse>(pharmacyBranchEntity);

        return Response<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>.CreateSuccess(dto);
    }
}