using Coban.Domain.Entities.Base;
using Coban.Identity.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IdentityService.Persistence.DbContexts;

public sealed class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<UserEntity> UserEntities { get; set; }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker.Entries<BaseEntity>();

        int currentUserId = 1;

        foreach (EntityEntry<BaseEntity> entity in datas)
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedTime = DateTime.UtcNow;
                entity.Entity.CreatedUserId = currentUserId;
            }
            else if (entity.State == EntityState.Modified)
            {
                entity.Entity.UpdatedTime = DateTime.UtcNow;
                entity.Entity.UpdatedUserId = currentUserId;
            }
            else if (entity.State == EntityState.Deleted)
            {
                entity.Entity.Status = Coban.Domain.Enums.Base.EEntityStatus.Deleted;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}
