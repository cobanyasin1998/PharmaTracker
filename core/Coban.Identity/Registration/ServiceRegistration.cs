using Coban.Identity.Services.Abstractions;
using Coban.Identity.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Coban.Identity.Registration;

public static class ServiceRegistration
{
    public static void AddCoreIdentityServices(this IServiceCollection services)
    {
       services.AddScoped<ITokenService, TokenService>();
    }
}
