namespace PharmacyService.Application.Messages;

public static class ValidationMessages
{
    public static string Required(string fieldName) => $"{fieldName} is required.";
    public static string MinLength(string fieldName, int minLength) => $"{fieldName} must be at least {minLength} characters.";
    public static string MaxLength(string fieldName, int maxLength) => $"{fieldName} cannot be more than {maxLength} characters.";
}
