using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using Coban.Persistence.SeedData.Abstractions;
using Coban.Persistence.SeedData.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PharmacyService.Persistence.DbContexts;
using PharmacyService.Persistence.EntityFramework;
using PharmacyService.Persistence.SeedData;

namespace PharmacyService.Persistence.Registration;
public static class ServiceRegistration
{
    public static void AddPharmacyPersistenceServices(this IServiceCollection services)
    {
        DatabaseConnection(services);

        services.AddScoped<ISeedData, PharmacySeedData>();
        services.AddScoped<SeedDataManager>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }

    private static void DatabaseConnection(IServiceCollection services)
    {
        services.AddDbContext<PharmacyDbContext>(opt =>
        {
            opt.UseNpgsql("Host=localhost;Port=5432;Database=pharmacyServicePostgresDatabase;Username=pharmacyPostgres;Password=dRakyDKVyF5S");
        });
    }
}
