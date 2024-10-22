
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PharmacyService.Application.Pipelines.Validation;
using System.Reflection;

namespace PharmacyService.Application.Registration;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
        });
        services.AddAutoMapper(Assembly.GetExecutingAssembly());


    }
}
