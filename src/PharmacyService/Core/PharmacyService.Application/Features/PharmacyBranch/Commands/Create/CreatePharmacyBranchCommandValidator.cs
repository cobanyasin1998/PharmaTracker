using Coban.Application.GeneralExtensions.ValidationGeneralExtensions;
using FluentValidation;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Create;


public class CreatePharmacyBranchCommandValidator : AbstractValidator<CreatePharmacyBranchCommandRequest>
{
    public CreatePharmacyBranchCommandValidator()
    {
        RuleFor(p => p.Name)
                .ApplyCommonStringRules("Name");

   
    }
}
