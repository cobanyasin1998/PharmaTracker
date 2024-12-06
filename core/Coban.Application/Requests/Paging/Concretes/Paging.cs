using Coban.Application.Requests.Paging.Abstractions;

namespace Coban.Application.Requests.Paging.Concretes;

public abstract class Paging : IPaging
{
    public  int Page { get; set; } = 1;
    public  int Size { get; set; } = 10;

    public Paging(int page = 1, int size = 10)
    {
        Page = page > 0 ? page : 1;  
        Size = size > 0 ? size : 10; 
    }
}
