using Coban.Application.Requests.Paging.Abstractions;

namespace Coban.Application.Requests.Paging.Concretes;

public abstract class Paging : IPaging
{
    public virtual int Page { get; set; } = 0;
    public virtual int Size { get; set; } = 5;
}
