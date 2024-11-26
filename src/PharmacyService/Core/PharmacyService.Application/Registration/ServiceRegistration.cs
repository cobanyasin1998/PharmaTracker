using Coban.Application.Abstractions.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PharmacyService.Application.Registration;

public static class ServiceRegistration
{
    public static void AddPharmacyApplicationServices(this IServiceCollection services)
    {
        //FluentValidation servislerinin eklenmesi
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //AutoMapper servislerinin eklenmesi
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //MediatR servislerinin eklenmesi
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            //configuration.AddOpenBehavior(typeof(DecryptIdBehavior<,>));

            // configuration.AddOpenBehavior(typeof(RequestTransactionBehavior<,>));
            //configuration.AddOpenBehavior(typeof(ExceptionHandlingBehavior<,>));

        });
        //Business Rules servislerinin eklenmesi
        services.AddBusinessRules();
    }
    private static IServiceCollection AddBusinessRules(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var businessRuleTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract)
            .Where(type => type.GetInterfaces().Any(i => i.Name.StartsWith("I") && typeof(IBaseBusinessRule).IsAssignableFrom(i)));

        foreach (var implementationType in businessRuleTypes)
        {
            var interfaceType = implementationType.GetInterfaces()
                .FirstOrDefault(i => typeof(IBaseBusinessRule).IsAssignableFrom(i));

            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, implementationType);
            }
        }

        return services;
    }
}
