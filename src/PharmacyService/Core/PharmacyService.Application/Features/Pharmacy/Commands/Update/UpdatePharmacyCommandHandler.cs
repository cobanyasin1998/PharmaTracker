using AutoMapper;
using Coban.Application.Abstractions.Rules;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Services.Abstractions;
using Coban.GeneralDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.Pharmacy.Constants;
using PharmacyService.Application.Features.Pharmacy.Rules.Abstractions;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandHandler(IUnitOfWork _unitOfWork, IDataProtectService _dataProtectService, IPharmacyBusinessRule _pharmacyBusinessRules, IMapper _mapper) : IRequestHandler<UpdatePharmacyCommandRequest, IResponse<UpdatePharmacyCommandResponse, GeneralErrorDto>>
{
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
            return Response<UpdatePharmacyCommandResponse, GeneralErrorDto>.CreateFailureGetByIdNotFound(new GeneralErrorDto(PharmacyConstants.NotFound, ""));

        

        _mapper.Map(request, entity);

        _unitOfWork.PharmacyWriteRepository.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<UpdatePharmacyCommandResponse, GeneralErrorDto>
            .CreateSuccess(new UpdatePharmacyCommandResponse(entity.Id), PharmacyConstants.Updated);
    }
}
