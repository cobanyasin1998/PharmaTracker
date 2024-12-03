using FluentValidation;

namespace UserService.Application.Features.User.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
{
    public UpdateUserCommandValidator()
    {
       
    }
}