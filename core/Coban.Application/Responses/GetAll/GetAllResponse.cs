namespace Coban.Application.Responses.GetAll;

public class GetAllResponse<T>
{
    public List<T> Result { get; set; }
    public int TotalCount { get; set; }
    public int ResultCount { get; set; }
    public int TotalPage { get;  set; }
    public bool Next { get;  set; }
    public bool Previous { get;  set; }
    public bool Next3Page { get;  set; }
    public bool Previous3Page { get;  set; }
}
