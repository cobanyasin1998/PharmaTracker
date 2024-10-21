using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PharmacyService.Application.BaseRepository.Pharmacy;
using PharmacyService.Persistence.Contexts;
using PharmacyService.Persistence.Repositories.Pharmacy;

namespace PharmacyService.Persistence.Registration;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<PharmacyDbContext>(opt =>
        {
            opt.UseNpgsql(Configuration.Configuration.ConnectionString);
        });


        services.AddScoped<IPharmacyReadRepository, PharmacyReadRepository>();
        services.AddScoped<IPharmacyWriteRepository, PharmacyWriteRepository>();

    }
}
