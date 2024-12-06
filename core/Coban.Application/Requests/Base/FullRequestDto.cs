using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;
using Coban.Application.Requests.OrderBy.Dto;

namespace Coban.Application.Requests.Base;

public abstract class FullRequestDto
{
    public virtual Paging.Concretes.Paging Paging { get; set; }
    public virtual IEnumerable<FilterGroup> Filtering { get; set; }
    public virtual IEnumerable<Sorting> Sorting { get; set; }
    protected FullRequestDto(Paging.Concretes.Paging paging, IEnumerable<FilterGroup> filtering = null, IEnumerable<Sorting> sorting = null)
    {
        Paging = paging;
        Filtering = filtering ?? Enumerable.Empty<FilterGroup>();
        Sorting = sorting ?? Enumerable.Empty<Sorting>();
    }
}
