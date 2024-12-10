using AutoMapper;
using Coban.Application.DataProtection.Abstractions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranchContact.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Create;

public class CreatePharmacyBranchContactCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IDataProtectService _dataProtectService)
    : IRequestHandler<CreatePharmacyBranchContactCommandRequest, IResponse<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchContactCommandRequest request, CancellationToken cancellationToken)
    {

        long decryptedPharmacyEntityBranchId = _dataProtectService.Decrypt(request.PharmacyBranchEntityId);

        request.PharmacyBranchEntityId = string.Empty;

        PharmacyBranchContactEntity entity = _mapper.Map<CreatePharmacyBranchContactCommandRequest, PharmacyBranchContactEntity>(request);
        entity.PharmacyBranchEntityId = decryptedPharmacyEntityBranchId;

        await _unitOfWork.PharmacyBranchContactWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreatePharmacyBranchContactCommandResponse(entity.Id), PharmacyBranchContactConstants.Created);
    }
}