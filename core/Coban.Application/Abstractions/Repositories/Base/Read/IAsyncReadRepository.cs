using Coban.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Coban.Application.Abstractions.Repositories.Base.Read;

public interface IAsyncReadRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id, bool tracking = true, CancellationToken cancellationToken = default);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);
    IQueryable<T> GetAll(bool tracking = true);
}
