using FluentValidation;

namespace GroupService.Application.Features.Group.Commands.Create;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommandRequest>
{
    public CreateGroupCommandValidator()
    {
       
    }
}