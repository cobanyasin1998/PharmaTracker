using System.Text.RegularExpressions;

namespace Coban.Application.GeneralExtensions.ValidationGeneralExtensions.Pharmacy;

public static class PharmacyValidationExtensions
{
    public static bool BeValidLicenseNumber(string licenseNumber)
    {
        if (string.IsNullOrEmpty(licenseNumber))
            return false;
        string pattern = @"^\d{4}-\d{3}-\d{4}$";
        return Regex.IsMatch(licenseNumber, pattern);
    }
}
