using FluentValidation;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Commands.Create;

public class CreateAuthDefinitionCommandValidator : AbstractValidator<CreateAuthDefinitionCommandRequest>
{
    public CreateAuthDefinitionCommandValidator()
    {
       
    }
}