using Coban.Application.Abstractions.Repositories.Base.Read;
using Coban.Domain.Entities.Base;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Coban.Persistence.Repositories.EntityFramework.Read;

public class ReadRepository<TEntity, TContext> 
    : IReadRepository<TEntity>, IRepository<TEntity>
    where TEntity : BaseEntity 
    where TContext : DbContext
{
    protected readonly TContext Context;

    public ReadRepository(TContext context)
    {
        Context = context;
    }
    public DbSet<TEntity> Table => Context.Set<TEntity>();

    public IQueryable<TEntity> GetAll(bool tracking = true)
    {
        IQueryable<TEntity>? query = Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }

    public TEntity? GetById(int id, bool tracking = true)
    {
        IQueryable<TEntity>? query = Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query.FirstOrDefault(x => x.Id == id);
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
    {
        IQueryable<TEntity>? query = Table.Where(predicate);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }
}
