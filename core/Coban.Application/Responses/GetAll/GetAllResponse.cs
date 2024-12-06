namespace Coban.Application.Responses.GetAll;

public class GetAllResponse<T>
{
    public List<T> Result { get; set; }
    public int TotalCount { get; set; }
    public int TotalPage { get;  set; }
}
