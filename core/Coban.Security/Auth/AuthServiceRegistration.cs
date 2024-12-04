using Coban.Security.Auth.JWT.Abstraction;
using Coban.Security.Auth.JWT.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace Coban.Security.Auth;

public static class AuthServiceRegistration
{
    public static IServiceCollection AddAuthSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();

        return services;
    }
}
