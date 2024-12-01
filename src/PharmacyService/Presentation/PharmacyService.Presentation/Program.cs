using Coban.Application.Registration;
using Coban.Infrastructure.Exceptions.Extensions;
using PharmacyService.Application.Registration;
using PharmacyService.Persistence.Registration;
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
        //using (var scope = app.Services.CreateScope())
        //{
        //    var seedManager = scope.ServiceProvider.GetRequiredService<SeedDataManager>();

        //    try
        //    {
        //        seedManager.SeedAll(); 
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred during seeding: {ex.Message}");
        //    }
        //}

        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi(); 

        }
        app.ConfigureCustomExceptionMiddleware();
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
