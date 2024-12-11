namespace Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;

public class Filter
{
    public String Member { get; set; } = String.Empty;
    public object? FilterValue { get; set; } = null;
    public String FilterOperator { get; set; } = String.Empty;
}
