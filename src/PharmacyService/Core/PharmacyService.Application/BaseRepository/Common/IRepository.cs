using Microsoft.EntityFrameworkCore;
using SharedLibrary.Core.Domain.Entities.Common;

namespace PharmacyService.Application.BaseRepository.Common;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
