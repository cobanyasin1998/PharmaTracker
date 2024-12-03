using FluentValidation;

namespace AuthFormService.Application.Features.AuthForm.Commands.Create;

public class CreateAuthFormCommandValidator : AbstractValidator<CreateAuthFormCommandRequest>
{
    public CreateAuthFormCommandValidator()
    {
       
    }
}