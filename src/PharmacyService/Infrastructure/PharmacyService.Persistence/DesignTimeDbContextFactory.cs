using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PharmacyService.Persistence.Contexts;

namespace PharmacyService.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PharmacyDbContext>
{
    public PharmacyDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<PharmacyDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.Configuration.ConnectionString);
        return new PharmacyDbContext(dbContextOptionsBuilder.Options);
    }
}
