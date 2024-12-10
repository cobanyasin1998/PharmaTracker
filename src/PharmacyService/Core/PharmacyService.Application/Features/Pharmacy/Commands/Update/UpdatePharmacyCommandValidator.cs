using Coban.Application.GeneralExtensions.ValidationGeneralExtensions;
using FluentValidation;
using PharmacyService.Application.Features.Pharmacy.Commands.Extensions;
using PharmacyService.Application.Features.Pharmacy.Constants;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandValidator : AbstractValidator<UpdatePharmacyCommandRequest>
{
    public UpdatePharmacyCommandValidator()
    {
   

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage(PharmacyConstants.StatusRequired);

        RuleFor(p => p.Name).ApplyCommonStringRules(PharmacyConstants.Name);
        RuleFor(p => p.Description).ApplyCommonStringRules(PharmacyConstants.Description, max: 100);
        RuleFor(p => p.LicenseNumber).ApplyCommonStringRules(PharmacyConstants.LicenseNumber)
            .Must(ValidationExtensions.BeValidLicenseNumber)
            .WithMessage(PharmacyConstants.LicenseNumberInvalidFormat);
    }

}
