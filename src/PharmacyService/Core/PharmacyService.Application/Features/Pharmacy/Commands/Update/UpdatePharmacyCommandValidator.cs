using Coban.Application.GeneralExtensions.ValidationGeneralExtensions;
using Coban.Application.GeneralExtensions.ValidationGeneralExtensions.Pharmacy;
using FluentValidation;
using PharmacyService.Application.Features.Pharmacy.Constants;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandValidator : AbstractValidator<UpdatePharmacyCommandRequest>
{
    public UpdatePharmacyCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage(PharmacyConstants.IdRequired)
            .NotNull().WithMessage(PharmacyConstants.IdRequired);

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage(PharmacyConstants.StatusRequired);

        RuleFor(p => p.Name).ApplyCommonStringRules(PharmacyConstants.Name);
        RuleFor(p => p.Description).ApplyCommonStringRules(PharmacyConstants.Description, max: 100);
        RuleFor(p => p.LicenseNumber).ApplyCommonStringRules(PharmacyConstants.LicenseNumber)
            .Must(PharmacyValidationExtensions.BeValidLicenseNumber)
            .WithMessage(PharmacyConstants.LicenseNumberInvalidFormat);
    }
}
