using Microsoft.EntityFrameworkCore;
using PharmacyService.Application.BaseRepository;
using PharmacyService.Persistence.Contexts;
using SharedLibrary.Core.Domain.Entities.Common;
using System.Linq.Expressions;

namespace PharmacyService.Persistence.Repositories.BaseRepositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly PharmacyDbContext _context;

    public ReadRepository(PharmacyDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }
    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        if (!tracking)
            query = query.AsNoTracking();        
        return query;
    }
    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        
        return await query.FirstOrDefaultAsync(method);

    }
    public async Task<T> GetByIdAsync(long id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id);

    }
}
