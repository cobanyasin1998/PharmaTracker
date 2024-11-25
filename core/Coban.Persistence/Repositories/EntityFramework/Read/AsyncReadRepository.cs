using Coban.Application.Abstractions.Repositories.Base.Read;
using Coban.Domain.Entities.Base;
using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Coban.Persistence.Repositories.EntityFramework.Read;

public class AsyncReadRepository<TEntity, TContext>
    : IAsyncReadRepository<TEntity>, IRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    protected readonly TContext Context;

    public AsyncReadRepository(TContext context)
    {
        Context = context;
    }
    public DbSet<TEntity> Table => Context.Set<TEntity>();

    public async Task<TEntity?> GetByIdAsync(int id, bool tracking = true, CancellationToken cancellationToken = default)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public IQueryable<TEntity> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
    {
        var query = Table.Where(predicate);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }

}
