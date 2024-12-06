namespace Coban.Application.Requests.OrderBy.Dto;

public class Sorting
{
    public string Field { get; set; }
    public bool Ascending { get; set; }

    public Sorting(string field, bool ascending = true)
    {
        Field = field;
        Ascending = ascending;
    }
}
