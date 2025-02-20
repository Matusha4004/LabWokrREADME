using Itmo.ObjectOrientedProgramming.Lab5.Core.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.DataBaseLayer.Extensions;
using Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer;
using Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddPostgresDatabase(config =>
        {
            config.Host = "localhost";
            config.Port = 6432;
            config.Username = "postgres";
            config.Password = "postgres";
        }).AddApplication().AddPresentationConsole();

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        CreatingDataBase initializer = serviceProvider.GetRequiredService<CreatingDataBase>();
        initializer.InitializeDatabase();

        using IServiceScope scope = serviceProvider.CreateScope();
        IConnectionWithConsole runner = scope.ServiceProvider.GetRequiredService<IConnectionWithConsole>();
        runner.Run();
    }
}