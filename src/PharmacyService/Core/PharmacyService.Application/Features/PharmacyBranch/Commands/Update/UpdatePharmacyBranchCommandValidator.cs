using FluentValidation;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Update;


public class UpdatePharmacyBranchCommandValidator : AbstractValidator<UpdatePharmacyBranchCommandRequest>
{
    public UpdatePharmacyBranchCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Pharmacy Branch Id is required.")
            .NotNull().WithMessage("Pharmacy Branch Id is required.");

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage("Pharmacy Branch Status is required.");


        //RuleFor(p => p.Name)
        //       .ApplyCommonStringRules("Pharmacy Name");


    }
}
