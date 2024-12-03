namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Rules;

public class GroupAuthDefinitionBusinessRule : IGroupAuthDefinitionBusinessRule
{
    private readonly IUnitOfWork _unitOfWork;
    public GroupAuthDefinitionBusinessRule(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}