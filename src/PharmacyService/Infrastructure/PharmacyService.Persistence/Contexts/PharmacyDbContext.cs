using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.Entities;
using PharmacyService.Domain.Entities.Common;

namespace PharmacyService.Persistence.Contexts;

public class PharmacyDbContext : DbContext
{
    public PharmacyDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<PharmacyEntity> PharmacyEntities { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();
        foreach (var entity in datas)
        {
            _ = entity.State switch
            {
                EntityState.Added => entity.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => entity.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow,
            };


        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PharmacyDbContext).Assembly);
    }
}
