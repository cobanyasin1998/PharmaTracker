namespace Coban.Application.Requests.OrderBy.Dto;

public class Sorting(string field, bool ascending = true)
{
    public string Field { get; set; } = field;
    public bool Ascending { get; set; } = ascending;
}
