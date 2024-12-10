using AutoMapper;
using Coban.Application.DataProtection.Abstractions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranchAddress.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;

public class CreatePharmacyBranchAddressCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IDataProtectService _dataProtectService)
    : IRequestHandler<CreatePharmacyBranchAddressCommandRequest, IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchAddressCommandRequest request, CancellationToken cancellationToken)
    {

        long decryptedPharmacyEntityBranchId = _dataProtectService.Decrypt(request.PharmacyBranchEntityId);

        request.PharmacyBranchEntityId = string.Empty;

        PharmacyBranchAddressEntity entity = _mapper.Map<CreatePharmacyBranchAddressCommandRequest, PharmacyBranchAddressEntity>(request);
        entity.PharmacyBranchEntityId = decryptedPharmacyEntityBranchId;

        await _unitOfWork.PharmacyBranchAddressWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreatePharmacyBranchAddressCommandResponse(entity.Id), PharmacyBranchAddressConstants.Created);
    }
}