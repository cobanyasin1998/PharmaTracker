using Coban.Application.BusinessRules.Abstractions;
using Coban.Application.Mediatr.Pipelines;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PharmacyService.Application.Registration;

public static class ServiceRegistration
{
    public static void AddPharmacyApplicationServices(this IServiceCollection services)
    {
     //   services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(DataProtectionBehavior<,>));
        });
        services.AddBusinessRules();
    }
    private static IServiceCollection AddBusinessRules(this IServiceCollection services)
    {
        Assembly? assembly = Assembly.GetExecutingAssembly();

        IEnumerable<Type>? businessRuleTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract)
            .Where(type => type.GetInterfaces().Any(i => i.Name.StartsWith('I') && typeof(IBaseBusinessRule).IsAssignableFrom(i)));

        foreach (Type? implementationType in businessRuleTypes)
        {
            Type? interfaceType = implementationType.GetInterfaces()
                .FirstOrDefault(i => typeof(IBaseBusinessRule).IsAssignableFrom(i));

            if (interfaceType != null)
                services.AddScoped(interfaceType, implementationType);
        }
        return services;
    }
}
