using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;

public class GetByIdPharmacyBranchAddressQueryHandler : IRequestHandler<GetByIdPharmacyBranchAddressQueryRequest, IResponse<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdPharmacyBranchAddressQueryHandler(IMapper mapper, IDataProtectService dataProtectService, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyBranchAddressQueryRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);
        PharmacyBranchAddressEntity? pharmacyBranchAddressEntity = await _unitOfWork.PharmacyBranchAddressReadRepository.GetByIdAsync(id, tracking: false, cancellationToken: cancellationToken);
        var dto = _mapper.Map<PharmacyBranchAddressEntity, GetByIdPharmacyBranchAddressQueryResponse>(pharmacyBranchAddressEntity);

        return Response<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>.CreateSuccess(dto);
    }
}
