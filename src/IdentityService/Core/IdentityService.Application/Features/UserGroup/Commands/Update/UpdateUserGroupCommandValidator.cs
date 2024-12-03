using FluentValidation;

namespace UserGroupService.Application.Features.UserGroup.Commands.Update;

public class UpdateUserGroupCommandValidator : AbstractValidator<UpdateUserGroupCommandRequest>
{
    public UpdateUserGroupCommandValidator()
    {
       
    }
}