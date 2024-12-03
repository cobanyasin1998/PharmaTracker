namespace RefreshTokenService.Application.Features.RefreshToken.Rules;

public class RefreshTokenBusinessRule : IRefreshTokenBusinessRule
{
    private readonly IUnitOfWork _unitOfWork;
    public RefreshTokenBusinessRule(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}