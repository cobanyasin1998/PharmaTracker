using FluentValidation;
using PharmacyService.Domain.Enums;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Update;



public class UpdatePharmacyBranchContactCommandValidator : AbstractValidator<UpdatePharmacyBranchContactCommandRequest>
{
    public UpdatePharmacyBranchContactCommandValidator()
    {

        RuleFor(p => p.Id)
          .NotEmpty().WithMessage("Pharmacy Branch Contact Id is required.")
          .NotNull().WithMessage("Pharmacy Branch Contact Id is required.");

        RuleFor(p => p.Status)
            .IsInEnum().WithMessage("Pharmacy Branch Contact Status is required.");

        RuleFor(x => x.Type)
           .IsInEnum()
           .WithMessage("Contact type must be valid (Phone, Email, Fax).");

        When(x => x.Type == EContactType.Phone, () =>
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Phone number must be in a valid format.");
        });

        When(x => x.Type == EContactType.Email, () =>
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email must be in a valid format.");
        });

        When(x => x.Type == EContactType.Fax, () =>
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("Fax number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Fax number must be in a valid format.");
        });
    }
}
