using Coban.Application.Registration;
using PharmacyService.Application.Registration;
using PharmacyService.Persistence.Registration;
using Coban.Infrastructure.Exceptions.Extensions;
using Coban.Infrastructure.Registration;
namespace PharmacyService.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        //Core katmanýndaki servislerin eklenmesi
        builder.Services.AddCoreApplicationServices();
        builder.Services.AddCoreInfrastructureServices();
        //Pharmacy katmanýndaki servislerin eklenmesi
        builder.Services.AddPharmacyApplicationServices();
        builder.Services.AddPharmacyPersistenceServices();
        builder.Services.AddSwaggerDocument(config =>
        {
            config.PostProcess = document =>
            {
                document.Info.Version = "v1";
                document.Info.Title = "My API";
                document.Info.Description = "A sample API using NSwag in .NET Core";
            };
        });
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi(); // Swagger UI ekranýný ekler

        }
        app.ConfigureCustomExceptionMiddleware();
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
