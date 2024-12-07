using Coban.Application.Repositories.Base.Write;
using Coban.Domain.Entities.Base;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Coban.Persistence.Repositories.EntityFramework.Write;

public class WriteRepository<TEntity, TContext>
    : IWriteRepository<TEntity>, IRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext Context;

    public WriteRepository(TContext context)
        => Context = context;
  
    public DbSet<TEntity> Table 
        => Context.Set<TEntity>();

    public bool Add(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry = Table.Add(entity);
        return entityEntry.State == EntityState.Added;
    }

    public void AddMany(IEnumerable<TEntity> entities) 
        => Table.AddRange(entities);

    public bool Delete(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public void DeleteMany(IEnumerable<TEntity> entities) 
        => Table.RemoveRange(entities);
   

    public bool Update(TEntity entity)
    {
        EntityEntry entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }

    public void UpdateMany(IEnumerable<TEntity> entities) 
        => Table.UpdateRange(entities);
    
}
