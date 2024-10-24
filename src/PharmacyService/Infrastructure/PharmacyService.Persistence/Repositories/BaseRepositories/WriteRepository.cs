using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PharmacyService.Application.BaseRepository;
using PharmacyService.Persistence.Contexts;
using SharedLibrary.Core.Domain.Entities.Common;

namespace PharmacyService.Persistence.Repositories.BaseRepositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly PharmacyDbContext _context;

    public WriteRepository(PharmacyDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }

    public bool Remove(T entity)
    {
        EntityEntry<T> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }
    public bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return true;

    }
    public async Task<bool> RemoveAsync(long id)
    {
        T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
        return Remove(model);
    }
    public bool Update(T entity)
    {
        EntityEntry entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
