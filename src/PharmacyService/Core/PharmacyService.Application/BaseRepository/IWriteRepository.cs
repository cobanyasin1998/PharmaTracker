using PharmacyService.Application.BaseRepository.Common;
using PharmacyService.Domain.Entities.Common;

namespace PharmacyService.Application.BaseRepository;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(List<T> datas);
    bool Remove(T entity);
    bool RemoveRange(List<T> datas);
    Task<bool> RemoveAsync(long id);

    bool Update(T entity);
    Task<int> SaveAsync();
}
