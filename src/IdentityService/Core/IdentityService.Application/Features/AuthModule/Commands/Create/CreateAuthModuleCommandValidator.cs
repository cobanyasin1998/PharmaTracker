using FluentValidation;

namespace AuthModuleService.Application.Features.AuthModule.Commands.Create;

public class CreateAuthModuleCommandValidator : AbstractValidator<CreateAuthModuleCommandRequest>
{
    public CreateAuthModuleCommandValidator()
    {
       
    }
}