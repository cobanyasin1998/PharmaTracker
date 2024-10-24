using FluentValidation;
using SharedLibrary.Core.Application.Language;

namespace PharmacyService.Application.ExtensionsMethod;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string> IsValidName<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        ILocalizationService localizationService,
        string propertyName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage(localizationService.GetLocalizedValue($"{propertyName}Required"))
            .NotNull().WithMessage(localizationService.GetLocalizedValue($"{propertyName}Required"))
            .MinimumLength(5).WithMessage(localizationService.GetLocalizedValue($"{propertyName}MinLength"))
            .MaximumLength(100).WithMessage(localizationService.GetLocalizedValue($"{propertyName}MaxLength"));
    }
}
