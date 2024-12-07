using Coban.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Coban.Application.Repositories.Base.Read;

public interface IReadRepository<T> where T : BaseEntity
{
    T? GetById(int id, bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);
    IQueryable<T> GetAll(bool tracking = true);

}
