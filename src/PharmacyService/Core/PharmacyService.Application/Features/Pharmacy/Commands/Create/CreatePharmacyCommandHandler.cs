using AutoMapper;
using Coban.Application.BusinessRules.Utility;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Concretes;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Application.Features.Pharmacy.Constants;
using PharmacyService.Application.Features.Pharmacy.Rules.Abstractions;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmacyCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IPharmacyBusinessRule _pharmacyBusinessRules)
    : IRequestHandler<CreatePharmacyCommandRequest, IResponse<CreatePharmacyCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<CreatePharmacyCommandResponse, GeneralErrorDto>> Handle(CreatePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        await BusinessRuleValidator.CheckRulesAsync(
                  () => _pharmacyBusinessRules.IsPharmacyNameUnique(request.Name),
                  () => _pharmacyBusinessRules.IsPharmacyLicenseNumberUnique(request.LicenseNumber)
              );

        PharmacyEntity entity = _mapper.Map<PharmacyEntity>(request);

        await _unitOfWork.PharmacyWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<CreatePharmacyCommandResponse, GeneralErrorDto>
            .CreateSuccess(new CreatePharmacyCommandResponse(entity.Id),PharmacyConstants.Created);
    }
}
