using FluentValidation;

namespace GroupService.Application.Features.Group.Commands.Update;

public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommandRequest>
{
    public UpdateGroupCommandValidator()
    {
       
    }
}