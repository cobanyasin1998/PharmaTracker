using PharmacyService.Application.BaseRepository.Common;
using SharedLibrary.Core.Domain.Entities.Common;
using System.Linq.Expressions;

namespace PharmacyService.Application.BaseRepository;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
    Task<T> GetByIdAsync(long id, bool tracking = true);
}
