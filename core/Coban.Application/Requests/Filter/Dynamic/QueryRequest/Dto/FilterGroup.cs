namespace Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;

public class FilterGroup
{
    public IEnumerable<Filter> Filters { get; set; }
    public IEnumerable<FilterGroup> ChildGroups { get; set; }
    public string IntergroupLogic { get; set; }
    public string InterfilterOperator { get; set; }

    public FilterGroup(IEnumerable<Filter> filters, IEnumerable<FilterGroup> childGroups = null, string intergroupLogic = "and", string interfilterOperator = "and")
    {
        Filters = filters ?? Enumerable.Empty<Filter>();
        ChildGroups = childGroups ?? Enumerable.Empty<FilterGroup>();
        IntergroupLogic = intergroupLogic;
        InterfilterOperator = interfilterOperator;
    }
}
