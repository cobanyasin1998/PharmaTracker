namespace Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;

public class Filter
{
    public string Member { get; set; }
    public object FilterValue { get; set; }
    public string FilterOperator { get; set; }
}
