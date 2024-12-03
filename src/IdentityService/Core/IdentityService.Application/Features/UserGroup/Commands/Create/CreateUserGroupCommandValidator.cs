using FluentValidation;

namespace UserGroupService.Application.Features.UserGroup.Commands.Create;

public class CreateUserGroupCommandValidator : AbstractValidator<CreateUserGroupCommandRequest>
{
    public CreateUserGroupCommandValidator()
    {
       
    }
}