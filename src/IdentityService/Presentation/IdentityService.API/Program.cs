using IdentityService.Persistence.Registration;
using IdentityService.Application.Registration;
using Coban.Application.Registration;
using Coban.Identity.Registration;
namespace IdentityService.API;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddCoreIdentityServices();
        builder.Services.AddCoreApplicationServices();
        builder.Services.AddIdentityApplicationServices();
        builder.Services.AddIdentityPersistenceServices(builder.Configuration);
  
        // Swagger Documentation
        builder.Services.AddSwaggerDocument(config =>
        {
            config.PostProcess = document =>
            {
                document.Info.Version = "v1";
                document.Info.Title = "My API";
                document.Info.Description = "A sample API using NSwag in .NET Core";
            };
          

        });
        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
        }
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
