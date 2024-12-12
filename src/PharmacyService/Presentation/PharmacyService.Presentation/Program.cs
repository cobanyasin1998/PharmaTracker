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
using Coban.Infrastructure.Middlewares.BotDetection;
using Serilog;
using System.IO.Compression;
using PharmacyService.Presentation.SwaggerModel.Pharmacy;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace PharmacyService.Presentation;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Services Configuration
        ConfigureServices(builder);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new()
            {
                ValidateIssuer = true,           //Oluþturulacak token deðerini kimlerin/ hangi originlerin/sitelerin kullanýcý belirlediðimiz deðerdir.
                ValidateAudience = true,         //Oluþturulacak token deðerinin kimin daðýttýðýný ifade edeceðimiz alandýr
                ValidateLifetime = true,         //Oluþturulacak token deðerinin süresini kontrol edecek olan doðrulamadýr.
                ValidateIssuerSigningKey = true, //Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu security key verisinin doðrulanmasýdýr.
                ValidAudience = builder.Configuration["JwtSettings:Audience"],
                LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null && expires > DateTime.UtcNow,
                ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecurityKey"]!)),
                NameClaimType = ClaimTypes.Name
            };

            opt.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    Console.WriteLine($"Token validated: {context.SecurityToken}");
                    return Task.CompletedTask;
                }
            };
        });
        // Serilog Configuration
        ConfigureSerilog(builder);

        WebApplication app = builder.Build();

        // Data Seeding
        SeedDatabase(app);

        // Middleware Configuration
        ConfigureMiddleware(app);

        app.Run();
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        // HttpContext Accessor
        builder.Services.AddHttpContextAccessor();

        // Controllers with JSON Options
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.Formatting = Formatting.Indented;
        })
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = new UppercaseFirstLetterNamingPolicy();
            options.JsonSerializerOptions.WriteIndented = true;
        });

        // Response Compression
        builder.Services.AddResponseCompression(opt =>
        {
            opt.EnableForHttps = true;
            opt.Providers.Add<GzipCompressionProvider>();
        });
        builder.Services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        });

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

        // Application Services
        builder.Services.AddCoreApplicationServices();
        builder.Services.AddPharmacyApplicationServices();
        builder.Services.AddPharmacyPersistenceServices(builder.Configuration);

        // Endpoints API Explorer
        builder.Services.AddEndpointsApiExplorer();
    }

    private static void ConfigureSerilog(WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq(builder.Configuration.GetSection("Serilog")["Seq"]!)
                .ReadFrom.Configuration(context.Configuration);
        });
    }

    private static void SeedDatabase(WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        SeedDataManager seedManager = scope.ServiceProvider.GetRequiredService<SeedDataManager>();

        try
        {
            seedManager.SeedAll().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during seeding: {ex.Message}");
        }
    }

    private static void ConfigureMiddleware(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
        }
        app.UseAuthentication();
        app.UseAuthorization();

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
        app.MapControllers();
    }
}
