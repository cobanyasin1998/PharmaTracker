using FluentValidation;

namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Create;

public class CreateRefreshTokenCommandValidator : AbstractValidator<CreateRefreshTokenCommandRequest>
{
    public CreateRefreshTokenCommandValidator()
    {
       
    }
}