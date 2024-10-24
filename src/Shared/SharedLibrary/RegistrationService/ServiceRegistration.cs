using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Core.Application.Cache;
using SharedLibrary.Core.Application.Language;
using SharedLibrary.Infrastructure.Cache;
using SharedLibrary.Infrastructure.Language;

namespace SharedLibrary.RegistrationService;

public static class ServiceRegistration
{
    public static void AddSharedLibraryServices(this IServiceCollection services, string redisConnectionString)
    {
        services.AddSingleton<ICacheService>(provider => new RedisCacheService(redisConnectionString));
        services.AddSingleton<ILocalizationService, LocalizationService>();
    }
}
