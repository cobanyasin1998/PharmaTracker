namespace Coban.Application.GeneralExtensions.IQueryableExtensions;

public static class PagingExtensions
{
    public static IQueryable<T> ApplyPaging<T>(
           this IQueryable<T> query,
           int pageNumber,
           int pageSize)
    {
        int maxPageSize = 100; 
        int maxPageNumber = 1000;

        pageSize = Math.Min(pageSize, maxPageSize);
        pageNumber = Math.Min(pageNumber, maxPageNumber);

        if (pageNumber <= 0) pageNumber = 1;
        if (pageSize <= 0) pageSize = 10;

        return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}
