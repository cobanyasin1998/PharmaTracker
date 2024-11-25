using AutoMapper;
using Coban.Application.Abstractions.Rules;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmacyCommandHandler : IRequestHandler<CreatePharmacyCommandRequest, IResponse<CreatePharmacyCommandResponse, GeneralErrorDTO>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePharmacyCommandHandler(
        IMapper mapper,
        IDataProtectService dataProtectService,
        IUnitOfWork unitOfWork
        )
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse<CreatePharmacyCommandResponse, GeneralErrorDTO>> Handle(CreatePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        PharmacyEntity entity = _mapper.Map<CreatePharmacyCommandRequest, PharmacyEntity>(request);
        //await BusinessRuleValidator.CheckRulesAsync(
        //          () => _pharmacyBusinessRules.IsPharmacyNameUnique(request.Name),
        //          () => _pharmacyBusinessRules.IsPharmacyLicenseNumberUnique(request.LicenseNumber)
        //      );
        await _unitOfWork.AsyncPharmacyWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return Response<CreatePharmacyCommandResponse, GeneralErrorDTO>
            .CreateSuccess(new CreatePharmacyCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
