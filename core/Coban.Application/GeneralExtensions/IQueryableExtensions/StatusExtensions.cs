using Coban.Domain.Entities.Base;

namespace Coban.Application.GeneralExtensions.IQueryableExtensions;

public static class StatusExtensions
{
    public static IQueryable<T> OnlyActive<T>(this IQueryable<T> query) where T : BaseEntity 
        => query.Where(x => x.Status == Domain.Enums.Base.EEntityStatus.Active);

    public static IQueryable<T> OnlyDeleted<T>(this IQueryable<T> query) where T : BaseEntity 
        => query.Where(x => x.Status == Domain.Enums.Base.EEntityStatus.Deleted);
}
