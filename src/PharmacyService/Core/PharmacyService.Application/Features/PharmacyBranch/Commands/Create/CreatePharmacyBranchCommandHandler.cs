using AutoMapper;
using Coban.Application.BusinessRules.Utility;
using Coban.Application.DataProtection.Abstractions;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.PharmacyBranch.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Create;

public class CreatePharmacyBranchCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IDataProtectService _dataProtectService)
    : IRequestHandler<CreatePharmacyBranchCommandRequest, IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchCommandRequest request, CancellationToken cancellationToken)
    {

        long decryptedPharmacyEntityId = _dataProtectService.Decrypt(request.PharmacyEntityId);

        request.PharmacyEntityId = string.Empty;

        PharmacyBranchEntity entity = _mapper.Map<CreatePharmacyBranchCommandRequest, PharmacyBranchEntity>(request);
        entity.PharmacyEntityId = decryptedPharmacyEntityId;

        await _unitOfWork.PharmacyBranchWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreatePharmacyBranchCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreatePharmacyBranchCommandResponse(entity.Id), PharmacyBranchConstants.Created);
    }
}
