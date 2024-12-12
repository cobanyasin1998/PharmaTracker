namespace Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;

public class FilterGroup(
    IEnumerable<Filter> filters, 
    IEnumerable<FilterGroup>? childGroups = null, 
    string intergroupLogic = "and", 
    string interfilterOperator = "and"
    )
{
    public IEnumerable<Filter> Filters { get; set; } = filters ?? [];
    public IEnumerable<FilterGroup> ChildGroups { get; set; } = childGroups ?? [];
    public string IntergroupLogic { get; set; } = intergroupLogic;
    public string InterfilterOperator { get; set; } = interfilterOperator;
}
