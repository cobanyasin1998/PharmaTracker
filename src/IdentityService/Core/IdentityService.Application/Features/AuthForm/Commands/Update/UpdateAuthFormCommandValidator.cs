using FluentValidation;

namespace AuthFormService.Application.Features.AuthForm.Commands.Update;

public class UpdateAuthFormCommandValidator : AbstractValidator<UpdateAuthFormCommandRequest>
{
    public UpdateAuthFormCommandValidator()
    {
       
    }
}