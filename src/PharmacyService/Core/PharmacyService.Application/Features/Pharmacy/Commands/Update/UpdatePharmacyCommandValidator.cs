using Coban.Application.GeneralExtensions.ValidationGeneralExtensions;
using FluentValidation;
using PharmacyService.Application.Features.Pharmacy.Constants;
using System.Text.RegularExpressions;

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
            .Must(BeValidLicenseNumber)
            .WithMessage(PharmacyConstants.LicenseNumberInvalidFormat);
    }

    public static bool BeValidLicenseNumber(string licenseNumber)
    {
        if (string.IsNullOrEmpty(licenseNumber))
            return false;

        string pattern = @"^\d{4}-\d{3}-\d{4}$";

        // Zaman aşımı süresi
        TimeSpan timeout = TimeSpan.FromMilliseconds(500); // 500 ms

        try
        {
            return Regex.IsMatch(licenseNumber, pattern, RegexOptions.None, timeout);
        }
        catch (RegexMatchTimeoutException)
        {
            // Zaman aşımı durumunda false döner
            return false;
        }
    }
}
