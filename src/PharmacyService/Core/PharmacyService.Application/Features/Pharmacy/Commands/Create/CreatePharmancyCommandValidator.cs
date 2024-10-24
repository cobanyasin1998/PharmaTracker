using FluentValidation;
using PharmacyService.Application.ExtensionsMethod;
using SharedLibrary.Core.Application.Language;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmancyCommandValidator : AbstractValidator<CreatePharmacyCommandRequest>
{
    public CreatePharmancyCommandValidator(ILocalizationService localizationService)
    {
        RuleFor(p => p.Name)
            .IsValidName(localizationService, "PharmacyName");
        RuleFor(p => p.Description)
            .IsValidName(localizationService, "PharmacyDescription");
    }
}