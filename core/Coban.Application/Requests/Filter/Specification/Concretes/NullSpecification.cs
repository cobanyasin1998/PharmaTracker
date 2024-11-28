using Coban.Application.Requests.Filter.Specification.Abstractions;
using System.Linq.Expressions;

namespace Coban.Application.Requests.Filter.Specification.Concretes;

public class NullSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> ToExpression() 
        => x => true;
  
}
