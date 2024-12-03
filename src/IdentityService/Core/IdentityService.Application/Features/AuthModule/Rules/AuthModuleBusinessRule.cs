namespace AuthModuleService.Application.Features.AuthModule.Rules;

public class AuthModuleBusinessRule : IAuthModuleBusinessRule
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthModuleBusinessRule(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}