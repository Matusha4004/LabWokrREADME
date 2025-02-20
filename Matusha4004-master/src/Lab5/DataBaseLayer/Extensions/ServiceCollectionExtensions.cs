using Itmo.Dev.Platform.Postgres.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Core.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.DataBaseLayer.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.DataBaseLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPostgresDatabase(
        this IServiceCollection services,
        Action<PostgresConnectionConfiguration> configure)
    {
        var configuration = new PostgresConnectionConfiguration();
        configure(configuration);

        services.AddSingleton(configuration);
        services.AddSingleton<CreatingDataBase>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ITransitionRepository, TransitionRepository>();

        return services;
    }
}