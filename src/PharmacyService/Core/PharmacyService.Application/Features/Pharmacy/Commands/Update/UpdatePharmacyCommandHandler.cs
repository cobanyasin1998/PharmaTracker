using AutoMapper;
using Coban.Application.Abstractions.Rules;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Features.Pharmacy.Rules.Abstractions;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandHandler : IRequestHandler<UpdatePharmacyCommandRequest, IResponse<UpdatePharmacyCommandResponse, GeneralErrorDTO>>
{
    private readonly IMapper _mapper;
    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPharmacyBusinessRule _pharmacyBusinessRules;

    public UpdatePharmacyCommandHandler(IMapper mapper, IDataProtectService dataProtectService, IUnitOfWork unitOfWork, IPharmacyBusinessRule pharmacyBusinessRules)
    {
        _mapper = mapper;
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
        _pharmacyBusinessRules = pharmacyBusinessRules;
    }

    public async Task<IResponse<UpdatePharmacyCommandResponse, GeneralErrorDTO>> Handle(UpdatePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);

        await BusinessRuleValidator.CheckRulesAsync(
            () => _pharmacyBusinessRules.IsPharmacyNameUnique(request.Name, id),
            () => _pharmacyBusinessRules.IsPharmacyLicenseNumberUnique(request.LicenseNumber, id)
        );

        var entity = await _unitOfWork.AsyncPharmacyReadRepository
            .GetWhere(y => y.Id == id, tracking: true)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new InvalidOperationException("Pharmacy Not Found");
        }

      

        entity.Status = request.Status;
        entity.LicenseNumber = request.LicenseNumber;
        entity.Name = request.Name;
        entity.Description = request.Description;
        

        // Veritabanında Güncelleme ve Kaydetme
        _unitOfWork.AsyncPharmacyWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Başarılı Yanıt Dönülmesi
        return Response<UpdatePharmacyCommandResponse, GeneralErrorDTO>
            .CreateSuccess(new UpdatePharmacyCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
