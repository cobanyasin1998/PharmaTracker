using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.Entities;
using SharedLibrary.Core.Domain.Entities.Common;

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

        int currentUserId = 1;

        foreach (var entity in datas)
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedDate = DateTime.UtcNow;
                entity.Entity.CreatedUserId = currentUserId;
            }
            else if (entity.State == EntityState.Modified)
            {
                entity.Entity.UpdatedDate = DateTime.UtcNow;
                entity.Entity.UpdatedUserId = currentUserId; 
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PharmacyDbContext).Assembly);
    }
}
