
using PharmaGateway.API.Routes.PharmacyService.Pharmacy.Clusters;
using PharmaGateway.API.Routes.PharmacyService.Pharmacy.Routes;

namespace PharmaGateway.API;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


        builder.Services.AddReverseProxy()
       .LoadFromMemory(
            GetRoutes.PharmacyGetRoutes(),
            GetClusters.PharmacyGetCluster()
            );



        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
        WebApplication app = builder.Build();
        app.UseCors("AllowAllOrigins");
        app.MapReverseProxy();
        app.Run();
    }
}
