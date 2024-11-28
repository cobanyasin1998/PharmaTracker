using System.Linq.Expressions;

namespace Coban.Application.Requests.Filter.Specification.Abstractions;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> ToExpression();
}
