using Coban.Application.GeneralExtensions.ValidationGeneralExtensions;
using Coban.Application.GeneralExtensions.ValidationGeneralExtensions.Pharmacy;
using FluentValidation;
using PharmacyService.Application.Features.Pharmacy.Constants;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmancyCommandValidator : AbstractValidator<CreatePharmacyCommandRequest>
{
    public CreatePharmancyCommandValidator()
    {
        RuleFor(p => p.Name).ApplyCommonStringRules(PharmacyConstants.Name);
        RuleFor(p => p.Description).ApplyCommonStringRules(PharmacyConstants.Description, max: 100);
        RuleFor(p => p.LicenseNumber).ApplyCommonStringRules(PharmacyConstants.LicenseNumber)
            .Must(PharmacyValidationExtensions.BeValidLicenseNumber)
            .WithMessage(PharmacyConstants.LicenseNumberInvalidFormat);
    }

}
