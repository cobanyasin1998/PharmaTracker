using FluentValidation;

namespace Coban.Application.GeneralExtensions.ValidationGeneralExtensions;

public static class GeneralStringValidationExtensions
{
    public static IRuleBuilderOptions<T, String> ApplyCommonStringRules<T>(
           this IRuleBuilder<T, String> ruleBuilder,
           String fieldName,
           int min = 3,
           int max = 20)
    {
        return ruleBuilder
            .NotEmpty().WithMessage($"{fieldName} is required.")
            .MinimumLength(min).WithMessage($"{fieldName} must not be less than {min} characters.")
            .MaximumLength(max).WithMessage($"{fieldName} must not exceed {max} characters.");
    }
}
