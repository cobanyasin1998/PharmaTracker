namespace AuthDefinitionService.Application.Features.AuthDefinition.Rules;

public class AuthDefinitionBusinessRule : IAuthDefinitionBusinessRule
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthDefinitionBusinessRule(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}