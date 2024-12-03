using Coban.Application.Services.Abstractions;
using Coban.Application.Services.Concretes;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace Coban.Application.Registration;

public static class ServiceRegistration
{
    public static void AddCoreApplicationServices(this IServiceCollection services)
    {
        AddDataProtection(services);
    }

    private static void AddDataProtection(IServiceCollection services)
    {
        IDataProtectionProvider dataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo("./Keys"));
        services.AddSingleton(dataProtectionProvider);

        services.AddSingleton(sp =>
        {
            IDataProtectionProvider provider = sp.GetRequiredService<IDataProtectionProvider>();
            return provider.CreateProtector("CorePurpose");
        });

        services.AddSingleton<IDataProtectService, DataProtectService>();
    }
}