using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Create;

public class CreatePharmacyBranchCommandHandler : IRequestHandler<CreatePharmacyBranchCommandRequest, IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDataProtectService _dataProtectService;

    public CreatePharmacyBranchCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IDataProtectService dataProtectService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _dataProtectService = dataProtectService;
    }

    public async Task<IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchCommandRequest request, CancellationToken cancellationToken)
    {
        long decryptedPharmacyEntityId = _dataProtectService.Decrypt(request.PharmacyEntityId);

        request.PharmacyEntityId = null;

        PharmacyBranchEntity entity = _mapper.Map<CreatePharmacyBranchCommandRequest, PharmacyBranchEntity>(request);
        entity.PharmacyEntityId = decryptedPharmacyEntityId;
        await _unitOfWork.PharmacyBranchWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreatePharmacyBranchCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreatePharmacyBranchCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
