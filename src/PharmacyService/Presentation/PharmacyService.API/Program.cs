using PharmacyService.Application.Registration;
using PharmacyService.Persistence.Registration;
using PharmancyService.Infrastructure.Registration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();//Client'tan gelen request neticesinde httpContext nesnesine katmanlardali class'lar üzerinden(Business lOgic) eriþebilmemizi saðlayan bir servistir.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastruceServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
