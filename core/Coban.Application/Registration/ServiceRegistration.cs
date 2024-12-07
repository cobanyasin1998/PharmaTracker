using Coban.Application.DataProtection.Abstractions;
using Coban.Application.DataProtection.Concretes;
using Coban.Consts;
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
        IDataProtectionProvider dataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo(DataProtectionConsts.DirectoryKeyPath));
        services.AddSingleton(dataProtectionProvider);

        services.AddSingleton(sp =>
        {
            IDataProtectionProvider provider = sp.GetRequiredService<IDataProtectionProvider>();
            return provider.CreateProtector(DataProtectionConsts.CorePurpose);
        });

        services.AddSingleton<IDataProtectService, DataProtectService>();
    }
}