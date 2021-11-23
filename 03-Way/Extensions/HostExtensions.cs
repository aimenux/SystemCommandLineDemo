using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _03_Way.Extensions;

public static class HostExtensions
{
    public static Task<int> InvokeCommandsAsync(this IHost host, string[] args)
    {
        var commandLineBuilder = new CommandLineBuilder();
        var commands = host.Services.GetServices<Command>();
        foreach (var command in commands)
        {
            commandLineBuilder.AddCommand(command);
        }

        return commandLineBuilder
            .UseDefaults()
            .Build()
            .InvokeAsync(args);
    }
}