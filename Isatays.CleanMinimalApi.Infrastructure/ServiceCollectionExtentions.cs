using Isatays.CleanMinimalApi.Core.Interfaces;
using Isatays.CleanMinimalApi.Infrastructure.Persistense;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Isatays.CleanMinimalApi.Infrastructure;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection ConfigureInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration, string environmentName)
    {
        var connectionString = configuration.GetConnectionString("QomekDb")!;

        services.AddDbContext<FoodsContext>(options =>
        {
            options.UseNpgsql(connectionString,
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        3,
                        TimeSpan.FromSeconds(10),
                        null);
                });
        });

        return services;
    }

    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration, string environmentName)
    {
        services.AddScoped<IFoodsDbContext, FoodsContext>();

        return services;
    }
}
