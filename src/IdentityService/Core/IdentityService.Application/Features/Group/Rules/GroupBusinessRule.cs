namespace GroupService.Application.Features.Group.Rules;

public class GroupBusinessRule : IGroupBusinessRule
{
    private readonly IUnitOfWork _unitOfWork;
    public GroupBusinessRule(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}