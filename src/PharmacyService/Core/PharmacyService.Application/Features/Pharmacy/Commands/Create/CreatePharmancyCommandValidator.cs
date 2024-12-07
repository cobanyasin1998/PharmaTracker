using Coban.Application.GeneralExtensions.ValidationGeneralExtensions;
using FluentValidation;
using PharmacyService.Application.Features.Pharmacy.Constants;
using System.Text.RegularExpressions;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmancyCommandValidator : AbstractValidator<CreatePharmacyCommandRequest>
{
    public CreatePharmancyCommandValidator()
    {
        RuleFor(p => p.Name).ApplyCommonStringRules(PharmacyConstants.Name);
        RuleFor(p => p.Description).ApplyCommonStringRules(PharmacyConstants.Description, max: 100);
        RuleFor(p => p.LicenseNumber).ApplyCommonStringRules(PharmacyConstants.LicenseNumber)
            .Must(BeValidLicenseNumber)
            .WithMessage(PharmacyConstants.LicenseNumberInvalidFormat);
    }
    public static bool BeValidLicenseNumber(string licenseNumber)
    {
        if (string.IsNullOrEmpty(licenseNumber))
            return false;
        string pattern = @"^\d{4}-\d{3}-\d{4}$";
        return Regex.IsMatch(licenseNumber, pattern);
    }
}
