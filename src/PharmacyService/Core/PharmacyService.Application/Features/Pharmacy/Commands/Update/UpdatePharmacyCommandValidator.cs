using Coban.Application.GeneralExtensions.ValidationGeneralExtensions;
using FluentValidation;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandValidator : AbstractValidator<UpdatePharmacyCommandRequest>
{
    public UpdatePharmacyCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Pharmacy Id is required.")
            .NotNull().WithMessage("Pharmacy Id is required.");

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage("Pharmacy Status is required.");


        RuleFor(p => p.Name)
               .ApplyCommonStringRules("Pharmacy Name");

        RuleFor(p => p.Description)
            .ApplyCommonStringRules("Pharmacy Description");

        RuleFor(p => p.LicenseNumber)
            .ApplyCommonStringRules("Pharmacy License Number");
    }
}
