using Coban.Application.Registration;
using Coban.Infrastructure.Extensions;
using Coban.Persistence.SeedData.Managers;
using Microsoft.AspNetCore.ResponseCompression;
using PharmacyService.Application.Registration;
using PharmacyService.Persistence.Registration;
using Coban.Infrastructure.Middlewares.AdvancedRequestValidation;
using Coban.Infrastructure.Middlewares.AdvancedResponseValidation;
using Coban.Infrastructure.Middlewares.Maintenance;
using Coban.Infrastructure.Middlewares.PerformanceWatch;
using Coban.Infrastructure.Middlewares.Exception;
using Coban.Infrastructure.Middlewares.BlackList;


using Serilog;
using System.IO.Compression;
using Coban.Infrastructure.Middlewares.BotDetection;


namespace PharmacyService.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);


        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = new UppercaseFirstLetterNamingPolicy();
                options.JsonSerializerOptions.WriteIndented = true;

            });
        builder.Services.AddResponseCompression(opt =>
        {
            opt.EnableForHttps = true;
            opt.Providers.Add<GzipCompressionProvider>();

        });
        builder.Services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal; // Sýkýþtýrma seviyesi
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddCoreApplicationServices();

        builder.Services.AddPharmacyApplicationServices();
        builder.Services.AddPharmacyPersistenceServices(builder.Configuration);
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
        app.UseResponseCompression();
        app.ConfigureCustomExceptionMiddleware();
        app.ConfigurePerformanceWatchMiddleware();
        app.UseSerilogRequestLogging();
        app.ConfigureMaintenanceMiddleware();
        app.ConfigureAdvancedRequestValidationMiddleware();
        app.ConfigureAdvancedResponseValidationMiddleware();
        app.ConfigureCustomBlackListControlMiddleware();
        app.ConfigureBotDetectionMiddleware();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
