namespace Coban.Application.Requests.Paging.Abstractions;

public interface IPaging
{
    int Page { get; set; }
    int Size { get; set; }
}
