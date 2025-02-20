using Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer.ConsoleOut;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.PresentationLayer.Extensions;

public static class PresentaionCollectionExtension
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<IConsoleOut, BasicUserConsoleOut>();

        collection.AddScoped<IConsoleOut, AdminConsoleOut>();

        collection.AddScoped<IConnectionWithConsole, ConnectionWithConsoleOut>();

        return collection;
    }
}