using Coban.Application.Requests.Paging.Abstractions;

namespace Coban.Application.Requests.Paging.Concretes;

public class Paging(int page = 1, int size = 10) : IPaging
{
    public int Page { get; set; } = page > 0 ? page : 1;
    public int Size { get; set; } = size > 0 ? size : 10;
}
