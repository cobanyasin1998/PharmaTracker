using System.Text.RegularExpressions;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Extensions;

public static class ValidationExtensions
{
    public static bool BeValidLicenseNumber(string licenseNumber)
    {
        if (string.IsNullOrEmpty(licenseNumber))
            return false;

        string pattern = @"^\d{4}-\d{3}-\d{4}$";

        TimeSpan timeout = TimeSpan.FromMilliseconds(500); 

        try
        {
            return Regex.IsMatch(licenseNumber, pattern, RegexOptions.None, timeout);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}
