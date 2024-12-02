using FluentValidation;
using PharmacyService.Domain.Enums;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Create;

public class CreatePharmacyBranchContactCommandValidator : AbstractValidator<CreatePharmacyBranchContactCommandRequest>
{
    public CreatePharmacyBranchContactCommandValidator()
    {
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
