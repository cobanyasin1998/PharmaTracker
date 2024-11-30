﻿using Coban.Persistence.Repositories.EntityFramework.Abstractions;
using Coban.Persistence.SeedData.Abstractions;
using Coban.Persistence.SeedData.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PharmacyService.Persistence.DbContexts;
using PharmacyService.Persistence.EntityFramework;
using PharmacyService.Persistence.SeedData;

namespace PharmacyService.Persistence.Registration;
public static class ServiceRegistration
{
    public static void AddPharmacyPersistenceServices(this IServiceCollection services,string postgresqlConn)
    {
        DatabaseConnection(services, postgresqlConn);

        services.AddScoped<ISeedData, PharmacySeedData>();
       services.AddScoped<SeedDataManager>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }

    private static void DatabaseConnection(IServiceCollection services, string postgresqlConn)
    {
        services.AddDbContext<PharmacyDbContext>(opt =>
        {
            opt.UseNpgsql(postgresqlConn);
        });
    }
}