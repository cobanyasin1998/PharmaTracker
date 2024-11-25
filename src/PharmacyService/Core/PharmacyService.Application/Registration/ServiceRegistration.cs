using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PharmacyService.Application.Registration;

public static class ServiceRegistration
{
    public static void AddPharmacyApplicationServices(this IServiceCollection services)
    {
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
    }
}
