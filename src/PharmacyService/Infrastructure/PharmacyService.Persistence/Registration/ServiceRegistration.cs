using Coban.Persistence.SeedData.Abstractions;
using Coban.Persistence.SeedData.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PharmacyService.Application.Abstractions.UnitOfWork;
using PharmacyService.Persistence.DbContexts;
using PharmacyService.Persistence.EntityFramework;
using PharmacyService.Persistence.SeedData;

namespace PharmacyService.Persistence.Registration;
public static class ServiceRegistration
{
    public static void AddPharmacyPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseConnection(services,configuration);

        services.AddScoped<ISeedData, PharmacySeedData>();
        services.AddScoped<SeedDataManager>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }

    private static void DatabaseConnection(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("PharmacyDatabase")!;

        services.AddDbContext<PharmacyDbContext>(opt =>
        {
            opt.UseNpgsql(connectionString);
        });
    }
}
