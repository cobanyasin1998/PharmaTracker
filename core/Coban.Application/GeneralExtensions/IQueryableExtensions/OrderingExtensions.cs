using Coban.Application.Requests.OrderBy.Dto;
using System.Linq.Expressions;

namespace Coban.Application.GeneralExtensions.IQueryableExtensions;

public static class OrderingExtensions
{
    public static IQueryable<T> ApplyOrdering<T>(
       this IQueryable<T> query,
       List<Sorting> orderByProperties)
    {
        if (orderByProperties == null || !orderByProperties.Any())
            return query;

        IOrderedQueryable<T>? orderedQuery = null;

        for (int i = 0; i < orderByProperties.Count; i++)
        {
            var propertyName = orderByProperties[i].Field;
            var ascending = orderByProperties[i].Ascending;

            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, propertyName);
            var sortExpression = Expression.Lambda(property, param);

            string methodName = ascending
                ? (i == 0 ? "OrderBy" : "ThenBy")
                : (i == 0 ? "OrderByDescending" : "ThenByDescending");

            var resultExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.Type },
                (i == 0 ? query : orderedQuery).Expression,
                Expression.Quote(sortExpression));

            orderedQuery = (IOrderedQueryable<T>)query.Provider.CreateQuery<T>(resultExpression);
        }

        return orderedQuery ?? query;
    }

    public static IQueryable<T> ApplyOrdering<T>(
        this IQueryable<T> query,
        List<(Expression<Func<T, object>> KeySelector, bool Ascending)> keySelectors)
    {
        if (keySelectors == null || !keySelectors.Any())
            return query;

        IOrderedQueryable<T>? orderedQuery = null;

        for (int i = 0; i < keySelectors.Count; i++)
        {
            var keySelector = keySelectors[i].KeySelector;
            var ascending = keySelectors[i].Ascending;

            orderedQuery = i == 0
                ? (ascending ? query.OrderBy(keySelector) : query.OrderByDescending(keySelector))
                : (ascending ? orderedQuery.ThenBy(keySelector) : orderedQuery.ThenByDescending(keySelector));
        }

        return orderedQuery ?? query;
    }
}
