namespace Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;

public class FilterGroup
{
    public List<Filter> Filters { get; set; }
    public List<FilterGroup> ChildGroups { get; set; }
    public string IntergroupLogic { get; set; }
    public string InterfilterOperator { get; set; }
}
