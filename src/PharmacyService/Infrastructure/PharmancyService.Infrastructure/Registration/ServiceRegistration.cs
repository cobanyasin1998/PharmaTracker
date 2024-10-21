using Microsoft.Extensions.DependencyInjection;
using PharmacyService.Application.Abstraction.Language;
using PharmancyService.Infrastructure.Language;

namespace PharmancyService.Infrastructure.Registration;

public static class ServiceRegistration
{
    public static void AddInfrastruceServices(this IServiceCollection services)
    {
        services.AddScoped<ILocalizationService, LocalizationService>();

    }
}

