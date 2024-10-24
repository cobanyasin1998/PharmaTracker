using FluentValidation;
using PharmacyService.Application.ExtensionsMethod;
using SharedLibrary.Core.Application.Language;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandValidator : AbstractValidator<UpdatePharmacyCommandRequest>
{
    public UpdatePharmacyCommandValidator(ILocalizationService localizationService)
    {
        RuleFor(p => p.Name)
            .IsValidName(localizationService, "");
    }
}