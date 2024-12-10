using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;
using Coban.Application.Requests.OrderBy.Dto;

namespace Coban.Application.Requests.Base;

public abstract class FullRequestDto(
    Paging.Concretes.Paging paging,
    IEnumerable<FilterGroup>? filtering = null,
    IEnumerable<Sorting>? sorting = null)
{
    public virtual Paging.Concretes.Paging Paging { get; set; } = paging;
    public virtual IEnumerable<FilterGroup> Filtering { get; set; } = filtering ?? [];
    public virtual IEnumerable<Sorting> Sorting { get; set; } = sorting ?? [];
}
