using Coban.Application.Registration;
using Coban.Infrastructure.Exceptions.Extensions;
using Coban.Persistence.SeedData.Managers;
using PharmacyService.Application.Registration;
using PharmacyService.Persistence.Registration;
using Coban.Security.Middlewares.BlackList;
using Serilog;
using Coban.Infrastructure.AdvancedRequestValidation;
namespace PharmacyService.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddHttpContextAccessor();
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
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq("http://localhost:5341")               
                .ReadFrom.Configuration(context.Configuration);
        });
        WebApplication? app = builder.Build();

        using (IServiceScope scope = app.Services.CreateScope())
        {
            SeedDataManager? seedManager = scope.ServiceProvider.GetRequiredService<SeedDataManager>();

            try
            {
                seedManager.SeedAll().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during seeding: {ex.Message}");
            }
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();

        }
        app.ConfigureCustomExceptionMiddleware();
        app.UseSerilogRequestLogging(); // HTTP request loglarý için
        app.ConfigureAdvancedRequestValidationMiddleware();
 
        app.ConfigureCustomBlackListControlMiddleware();
       
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
