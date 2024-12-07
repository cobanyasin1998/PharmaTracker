namespace PharmacyService.Application.Features.Pharmacy.Constants;

public static class PharmacyConstants
{
    private const string Prefix = "Pharmacy";

    public const string Created = $"{Prefix}Created";
    public const string Updated = $"{Prefix} Updated";
    public const string Deleted = $"{Prefix} Deleted";
    public const string NotFound = $"{Prefix}NotFound";

    public const string Name = $"{Prefix} Name";
    public const string Description = $"{Prefix} Description";
    public const string LicenseNumber = $"{Prefix} License Number";

    public const string NameAlreadyExists = $"{Prefix}NameAlreadyExists";
    public const string LicenseNumberAlreadyExists = $"{Prefix}LicenseNumberAlreadyExists";
 
    public const string LicenseNumberInvalidFormat = $"Invalid License Number Format. Format should be XXXX-XXX-XXXX.";



    public const string IdRequired = $"{Prefix} Id is required.";
    public const string StatusRequired = $"{Prefix} Status is required.";
}
