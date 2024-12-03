using FluentValidation;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Create;

public class CreateGroupAuthDefinitionCommandValidator : AbstractValidator<CreateGroupAuthDefinitionCommandRequest>
{
    public CreateGroupAuthDefinitionCommandValidator()
    {
       
    }
}