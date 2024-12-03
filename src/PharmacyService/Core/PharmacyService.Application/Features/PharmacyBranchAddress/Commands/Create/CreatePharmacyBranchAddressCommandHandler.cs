using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;

public class CreatePharmacyBranchAddressCommandHandler : IRequestHandler<CreatePharmacyBranchAddressCommandRequest, IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePharmacyBranchAddressCommandHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchAddressCommandRequest request, CancellationToken cancellationToken)
    {

        long decryptedPharmacyBranchEntityId = _dataProtectService.Decrypt(request.PharmacyBranchEntityId);

        request.PharmacyBranchEntityId = null;

        PharmacyBranchAddressEntity entity = _mapper.Map<CreatePharmacyBranchAddressCommandRequest, PharmacyBranchAddressEntity>(request);
        entity.PharmacyBranchEntityId = decryptedPharmacyBranchEntityId;
        await _unitOfWork.PharmacyBranchAddressWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreatePharmacyBranchAddressCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
