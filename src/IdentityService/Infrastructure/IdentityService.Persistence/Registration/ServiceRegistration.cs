using IdentityService.Persistence.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Persistence.Registration;

public static class ServiceRegistration
{
    public static void AddIdentityPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseConnection(services, configuration);
    }

    private static void DatabaseConnection(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("IdentityDatabase")!;

        services.AddDbContext<IdentityDbContext>(opt =>
        {
            //opt.UseNpgsql(connectionString); // burası mssql olacak
        });
    }
}
