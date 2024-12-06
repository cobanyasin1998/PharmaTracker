using Coban.Application.Requests.Filter.Dynamic.QueryRequest.Dto;
using System.Linq.Expressions;

namespace Coban.Application.Requests.Filter.Dynamic.Extensions;

public static class FilterExtensions
{
    public static IQueryable<T> ApplyFilters<T>(
        this IQueryable<T> query,
        IEnumerable<FilterGroup> filterGroups)
    {
        if (filterGroups == null || !filterGroups.Any())
            return query;

        ParameterExpression parameter = Expression.Parameter(typeof(T), "x");

        Expression combinedExpression = (Expression)null;

        foreach (FilterGroup item in filterGroups)
        {
            Expression expressionGroup = BuildExpression(parameter, item);
            if (expressionGroup is not null)
            {
                if (combinedExpression is null)
                    combinedExpression = expressionGroup;
                else
                    combinedExpression = CombineExpressions(new List<Expression> { combinedExpression, expressionGroup }, item.IntergroupLogic);

            }

        }
        if (combinedExpression is not null)
        {
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
            query = query.Where(lambda);
        }

        return query;
    }

    private static Expression BuildExpression(ParameterExpression parameter, FilterGroup filterGroup)
    {
        List<Expression> expressions = new List<Expression>();

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
                Expression childExpression = BuildExpression(parameter, childGroup);
                if (childExpression is not null)
                    expressions.Add(childExpression);
            }
        }

        if (!expressions.Any())
            return null;

        return CombineExpressions(expressions, filterGroup.InterfilterOperator);
    }

    private static Expression CombineExpressions(List<Expression> expressions, string groupOperator)
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

        switch (filter.FilterOperator.ToLower())
        {
            case "==":
            case "equals":
                return Expression.Equal(member, constant);

            case "!=":
            case "notequals":
                return Expression.NotEqual(member, constant);

            case ">":
            case "greaterthan":
                return Expression.GreaterThan(member, constant);

            case "<":
            case "lessthan":
                return Expression.LessThan(member, constant);

            case ">=":
            case "greaterthanorequal":
                return Expression.GreaterThanOrEqual(member, constant);

            case "<=":
            case "lessthanorequal":
                return Expression.LessThanOrEqual(member, constant);

            case "contains":
                return Expression.Call(member, "Contains", null, constant);

            case "startswith":
                return Expression.Call(member, "StartsWith", null, constant);

            case "endswith":
                return Expression.Call(member, "EndsWith", null, constant);

            case "isnull":
                return Expression.Equal(member, Expression.Constant(null));

            case "isnotnull":
                return Expression.NotEqual(member, Expression.Constant(null));

            default:
                throw new NotSupportedException($"Unsupported filter operator: {filter.FilterOperator}");
        }
    }
}
