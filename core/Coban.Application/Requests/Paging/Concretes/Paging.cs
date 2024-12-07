using Coban.Application.Requests.Paging.Abstractions;

namespace Coban.Application.Requests.Paging.Concretes;

public class Paging : IPaging
{
    public int Page { get; set; } 
    public int Size { get; set; } 

    public Paging(int page = 1, int size = 10)
    {
        Page = page > 0 ? page : 1;
        Size = size > 0 ? size : 10;
    }
}
