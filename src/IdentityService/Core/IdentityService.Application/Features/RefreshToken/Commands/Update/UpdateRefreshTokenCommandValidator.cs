using FluentValidation;

namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Update;

public class UpdateRefreshTokenCommandValidator : AbstractValidator<UpdateRefreshTokenCommandRequest>
{
    public UpdateRefreshTokenCommandValidator()
    {
       
    }
}