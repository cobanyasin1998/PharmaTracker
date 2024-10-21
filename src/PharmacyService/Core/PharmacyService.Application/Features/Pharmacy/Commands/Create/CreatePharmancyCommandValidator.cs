using FluentValidation;
using PharmacyService.Application.Abstraction.Language;
using PharmacyService.Application.ExtensionsMethod;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmancyCommandValidator : AbstractValidator<CreatePharmacyCommandRequest>
{
    public CreatePharmancyCommandValidator(ILocalizationService localizationService)
    {
        RuleFor(p => p.Name)
            .IsValidName(localizationService);
    }
}