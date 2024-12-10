using Coban.Application.Requests.OrderBy.Dto;
using System.Linq.Expressions;

namespace Coban.Application.GeneralExtensions.IQueryableExtensions;

public static class OrderingExtensions
{
    public static IQueryable<T> ApplyOrdering<T>(
     this IQueryable<T> query,
     IEnumerable<Sorting> orderByProperties)
    {
        if (orderByProperties == null || !orderByProperties.Any())
            return query;

        IOrderedQueryable<T>? orderedQuery = null;

        int i = 0;
        foreach (var orderByProperty in orderByProperties)
        {
            string propertyName = orderByProperty.Field;
            bool ascending = orderByProperty.Ascending;

            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            MemberExpression property = Expression.Property(param, propertyName);
            LambdaExpression sortExpression = Expression.Lambda(property, param);

            string methodName = AscendingOrDescending(ascending, i);

            MethodCallExpression resultExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.Type },
                (i == 0 ? query : orderedQuery).Expression,
                Expression.Quote(sortExpression));

            orderedQuery = (IOrderedQueryable<T>)query.Provider.CreateQuery<T>(resultExpression);
            i++;
        }

        return orderedQuery!;
    }


    public static IQueryable<T> ApplyOrdering<T>(
        this IQueryable<T> query,
        List<(Expression<Func<T, object>> KeySelector, bool Ascending)> keySelectors)
    {
        if (keySelectors == null || keySelectors.Count == 0)
            return query;

        IOrderedQueryable<T>? orderedQuery = null;

        for (int i = 0; i < keySelectors.Count; i++)
        {
            Expression<Func<T, object>> keySelector = keySelectors[i].KeySelector;
            bool ascending = keySelectors[i].Ascending;

            string methodName = AscendingOrDescending(ascending, i);

            orderedQuery = (IOrderedQueryable<T>)typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), typeof(object))
                .Invoke(null, new object[] { i == 0 ? query : orderedQuery, keySelector });
        }

        return orderedQuery;
    }

    private static string AscendingOrDescending(bool ascending, int i)
    {
        string baseMethod = i == 0 ? "OrderBy" : "ThenBy";
        return ascending ? baseMethod : $"{baseMethod}Descending";
    }
}
