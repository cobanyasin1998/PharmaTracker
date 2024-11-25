using Coban.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Coban.Persistence.Repositories.EntityFramework.Abstractions;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    DbSet<TEntity> Table { get; }
}
