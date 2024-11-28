using AutoMapper;
using Coban.Application.Abstractions.Rules;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using PharmacyService.Application.Features.Pharmacy.Rules.Abstractions;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmacyCommandHandler : IRequestHandler<CreatePharmacyCommandRequest, IResponse<CreatePharmacyCommandResponse, GeneralErrorDTO>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPharmacyBusinessRule _pharmacyBusinessRules;

    public CreatePharmacyCommandHandler(IMapper mapper, IDataProtectService dataProtectService, IUnitOfWork unitOfWork, IPharmacyBusinessRule pharmacyBusinessRules)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
        _pharmacyBusinessRules = pharmacyBusinessRules;
    }

    public async Task<IResponse<CreatePharmacyCommandResponse, GeneralErrorDTO>> Handle(CreatePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        await BusinessRuleValidator.CheckRulesAsync(
                  () => _pharmacyBusinessRules.IsPharmacyNameUnique(request.Name),
                  () => _pharmacyBusinessRules.IsPharmacyLicenseNumberUnique(request.LicenseNumber)
              );

        PharmacyEntity entity = _mapper.Map<CreatePharmacyCommandRequest, PharmacyEntity>(request);

        await _unitOfWork.AsyncPharmacyWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
 
        return Response<CreatePharmacyCommandResponse, GeneralErrorDTO>
            .CreateSuccess(new CreatePharmacyCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
