using IdentityService.Application.Abstractions.UnitOfWork;
using IdentityService.Persistence.DbContexts;
using IdentityService.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Persistence.Registration;

public static class ServiceRegistration
{
    public static void AddIdentityPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseConnection(services, configuration);
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }

    private static void DatabaseConnection(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("IdentityDatabase")!;

        services.AddDbContext<IdentityDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });
    }
}
