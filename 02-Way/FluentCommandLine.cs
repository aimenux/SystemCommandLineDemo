using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace _02_Way;

public class FluentCommandLine : IFluentCommandLine
{
    private readonly RootCommand _rootCommand;

    public FluentCommandLine(RootCommand rootCommand)
    {
        _rootCommand = rootCommand ?? throw new ArgumentNullException(nameof(rootCommand));
    }

    public Task<int> RunAsync(string[] args)
    {
        var commandLine = new CommandLineBuilder(_rootCommand)
            .UseDefaults()
            .Build();

        return commandLine.InvokeAsync(args);
    }
}