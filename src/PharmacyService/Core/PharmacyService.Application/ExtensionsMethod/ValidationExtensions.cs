using FluentValidation;
using PharmacyService.Application.Abstraction.Language;

namespace PharmacyService.Application.ExtensionsMethod;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string> IsValidName<T>(
        this IRuleBuilder<T, string> ruleBuilder, 
        ILocalizationService localizationService)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(localizationService.GetLocalizedValue($"NameRequired"))
            .NotNull().WithMessage(localizationService.GetLocalizedValue($"NameRequired"))
            .MinimumLength(5).WithMessage(localizationService.GetLocalizedValue("NameMinLength"))
            .MaximumLength(100).WithMessage(localizationService.GetLocalizedValue("NameMaxLength"));
    }
}
