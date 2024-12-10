namespace Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;

public class Filter
{
    public string Member { get; set; } = string.Empty;
    public object? FilterValue { get; set; } = null;
    public string FilterOperator { get; set; } = string.Empty;
}
