using AutoMapper;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Create;

public class CreatePharmacyBranchContactCommandHandler : IRequestHandler<CreatePharmacyBranchContactCommandRequest, IResponse<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePharmacyBranchContactCommandHandler(IDataProtectService dataProtectService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IResponse<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyBranchContactCommandRequest request, CancellationToken cancellationToken)
    {
        long decryptedPharmacyBranchEntityId = _dataProtectService.Decrypt(request.PharmacyBranchEntityId);

        request.PharmacyBranchEntityId = null;

        PharmacyBranchContactEntity entity = _mapper.Map<CreatePharmacyBranchContactCommandRequest, PharmacyBranchContactEntity>(request);
        entity.PharmacyBranchEntityId = decryptedPharmacyBranchEntityId;
        await _unitOfWork.PharmacyBranchContactWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreatePharmacyBranchContactCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
