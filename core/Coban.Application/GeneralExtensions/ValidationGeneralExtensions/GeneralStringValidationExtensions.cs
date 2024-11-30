using FluentValidation;

namespace Coban.Application.GeneralExtensions.ValidationGeneralExtensions;

public static class GeneralStringValidationExtensions
{
    public static IRuleBuilderOptions<T, string> ApplyCommonStringRules<T>(
           this IRuleBuilder<T, string> ruleBuilder, string fieldName)
    {
        return ruleBuilder
            .NotEmpty().WithMessage($"{fieldName} is required.")
            .MinimumLength(3).WithMessage($"{fieldName} must not be less than 3 characters.")
            .MaximumLength(100).WithMessage($"{fieldName} must not exceed 100 characters.");
    }
}
