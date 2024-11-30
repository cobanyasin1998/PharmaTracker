using Coban.Application.GeneralExtensions.ValidationGeneralExtensions;
using FluentValidation;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmancyCommandValidator : AbstractValidator<CreatePharmacyCommandRequest>
{
    public CreatePharmancyCommandValidator()
    {
        RuleFor(p => p.Name)
                .ApplyCommonStringRules("Pharmacy Name");

        RuleFor(p => p.Description)
            .ApplyCommonStringRules("Pharmacy Description");

        RuleFor(p => p.LicenseNumber)
            .ApplyCommonStringRules("Pharmacy License Number");
    }
}
