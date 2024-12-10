using Coban.Application.Requests.Filter.Specification.Abstractions;

namespace Coban.Application.Requests.Filter.Specification.Extensions;

public static class SpecificationExtensions
{
    public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> query, ISpecification<T> specification) 
        => query.Where(specification.ToExpression());
}
