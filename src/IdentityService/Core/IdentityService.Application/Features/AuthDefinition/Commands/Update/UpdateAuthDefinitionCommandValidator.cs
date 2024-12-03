using FluentValidation;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Commands.Update;

public class UpdateAuthDefinitionCommandValidator : AbstractValidator<UpdateAuthDefinitionCommandRequest>
{
    public UpdateAuthDefinitionCommandValidator()
    {
       
    }
}