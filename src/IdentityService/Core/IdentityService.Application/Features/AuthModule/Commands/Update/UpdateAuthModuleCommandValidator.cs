using FluentValidation;

namespace AuthModuleService.Application.Features.AuthModule.Commands.Update;

public class UpdateAuthModuleCommandValidator : AbstractValidator<UpdateAuthModuleCommandRequest>
{
    public UpdateAuthModuleCommandValidator()
    {
       
    }
}