using Coban.Domain.Entities.Base;

namespace Coban.Application.Abstractions.Repositories.Base.Write;

public interface IWriteRepository<T> where T : BaseEntity
{
    bool Add(T entity);
    void AddMany(IEnumerable<T> entities);
    bool Update(T entity);
    void UpdateMany(IEnumerable<T> entities);
    bool Delete(T entity);
    void DeleteMany(IEnumerable<T> entities);
}

