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
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandHandler : IRequestHandler<UpdatePharmacyCommandRequest, IResponse<UpdatePharmacyCommandResponse, GeneralErrorDto>>
{

    private readonly IDataProtectService _dataProtectService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPharmacyBusinessRule _pharmacyBusinessRules;

    public UpdatePharmacyCommandHandler( IDataProtectService dataProtectService, IUnitOfWork unitOfWork, IPharmacyBusinessRule pharmacyBusinessRules)
    {
      
        _dataProtectService = dataProtectService;
        _unitOfWork = unitOfWork;
        _pharmacyBusinessRules = pharmacyBusinessRules;
    }

    public async Task<IResponse<UpdatePharmacyCommandResponse, GeneralErrorDto>> Handle(UpdatePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        long id = _dataProtectService.Decrypt(request.Id);

        await BusinessRuleValidator.CheckRulesAsync(
            () => _pharmacyBusinessRules.IsPharmacyNameUnique(request.Name, id),
            () => _pharmacyBusinessRules.IsPharmacyLicenseNumberUnique(request.LicenseNumber, id)
        );

        PharmacyEntity? entity = await _unitOfWork.PharmacyReadRepository
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
        _unitOfWork.PharmacyWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Başarılı Yanıt Dönülmesi
        return Response<UpdatePharmacyCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdatePharmacyCommandResponse(_dataProtectService.Encrypt(entity.Id)));
    }
}
