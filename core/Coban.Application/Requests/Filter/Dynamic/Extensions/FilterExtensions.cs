using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;
using System.Linq.Expressions;

namespace Coban.Application.Requests.Filter.Dynamic.Extensions;

public static class FilterExtensions
{
    public static IQueryable<T> ApplyFilters<T>(
        this IQueryable<T> query,
        IEnumerable<FilterGroup>? filterGroups)
    {
        if (filterGroups is null || !filterGroups.Any())
            return query;

        ParameterExpression parameter = Expression.Parameter(typeof(T), "x");

        Expression? combinedExpression = null;

        foreach (FilterGroup item in filterGroups)
        {
            Expression? expressionGroup = BuildExpression(parameter, item);
            if (expressionGroup is not null)
            {
                if (combinedExpression is null)
                    combinedExpression = expressionGroup;
                else
                    combinedExpression = CombineExpressions([combinedExpression, expressionGroup], item.IntergroupLogic);

            }

        }
        if (combinedExpression is not null)
        {
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
            query = query.Where(lambda);
        }

        return query;
    }

    private static Expression? BuildExpression(ParameterExpression parameter, FilterGroup filterGroup)
    {
        List<Expression> expressions = [];

        if (filterGroup.Filters is not null)
        {
            foreach (QueryRequest.Dto.Filter filter in filterGroup.Filters)
            {
                Expression filterExpression = BuildFilterExpression(parameter, filter);
                if (filterExpression is not null)
                    expressions.Add(filterExpression);
            }
        }
        if (filterGroup.ChildGroups is not null)
        {
            foreach (FilterGroup childGroup in filterGroup.ChildGroups)
            {
                Expression? childExpression = BuildExpression(parameter, childGroup);
                if (childExpression is not null)
                    expressions.Add(childExpression);
            }
        }

        if (expressions.Count == 0)
            return null;

        return CombineExpressions(expressions, filterGroup.InterfilterOperator);
    }

    private static Expression CombineExpressions(List<Expression> expressions, String groupOperator)
    {
        return groupOperator?.ToLower() switch
        {
            "and" => expressions.Aggregate(Expression.AndAlso),
            "or" => expressions.Aggregate(Expression.OrElse),
            _ => throw new NotSupportedException($"Unsupported group operator: {groupOperator}")
        };
    }

    private static Expression BuildFilterExpression(ParameterExpression parameter, QueryRequest.Dto.Filter filter)
    {
        MemberExpression member = Expression.PropertyOrField(parameter, filter.Member);

        Expression constant;
        if (member.Type.IsEnum)
        {
            object enumValue = Enum.ToObject(member.Type, filter.FilterValue);
            constant = Expression.Constant(enumValue, member.Type);
        }
        else
            constant = Expression.Constant(filter.FilterValue);

        return filter.FilterOperator.ToLower() switch
        {
            "==" or "equals" => Expression.Equal(member, constant),
            "!=" or "notequals" => Expression.NotEqual(member, constant),
            ">" or "greaterthan" => Expression.GreaterThan(member, constant),
            "<" or "lessthan" => Expression.LessThan(member, constant),
            ">=" or "greaterthanorequal" => Expression.GreaterThanOrEqual(member, constant),
            "<=" or "lessthanorequal" => Expression.LessThanOrEqual(member, constant),
            "contains" => Expression.Call(member, "Contains", null, constant),
            "startswith" => Expression.Call(member, "StartsWith", null, constant),
            "endswith" => Expression.Call(member, "EndsWith", null, constant),
            "isnull" => Expression.Equal(member, Expression.Constant(null)),
            "isnotnull" => Expression.NotEqual(member, Expression.Constant(null)),
            _ => throw new NotSupportedException($"Unsupported filter operator: {filter.FilterOperator}"),
        };
    }
}
