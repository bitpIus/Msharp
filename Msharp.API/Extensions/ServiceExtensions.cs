using Microsoft.EntityFrameworkCore;
using Msharp.Application.Repositories;
using Msharp.Infrastructure.Context;

namespace Msharp.Api.Extensions;


public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                    .AllowAnyMethod()
                        .AllowAnyHeader());
        });

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("Msharp.Api")));

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IFactoryRepository, FactoryRepository>();


}