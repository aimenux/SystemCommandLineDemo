using System.CommandLine;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace _03_Way.Extensions;

public static class ServiceCollectionExtensions
{
    private static readonly Type CommandType = typeof(Command);

    public static void AddCommands(this IServiceCollection services)
    {
        var commands = Assembly
            .GetExecutingAssembly()
            .GetExportedTypes()
            .Where(x => x.IsClass && !x.IsAbstract && CommandType.IsAssignableFrom(x));

        foreach (var command in commands)
        {
            services.AddSingleton(CommandType, command);
        }
    }
}