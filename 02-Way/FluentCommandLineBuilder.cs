using System.CommandLine;

namespace _02_Way;

public class FluentCommandLineBuilder : IFluentCommandLineBuilder
{
    private readonly List<IFluentCommand> _subCommands = new();

    public IFluentCommandLineBuilder AddCommand(Action<IFluentCommandBuilder> configureCommand)
    {
        var commandBuilder = new FluentCommandBuilder();
        configureCommand(commandBuilder);
        var command = commandBuilder.Build();
        _subCommands.Add(command);
        return this;
    }

    public IFluentCommandLine Build()
    {
        var rootCommand = new RootCommand();

        var subCommands = _subCommands.Cast<FluentCommand>();

        foreach (var subCommand in subCommands)
        {
            rootCommand.AddCommand(subCommand);
        }

        return new FluentCommandLine(rootCommand);
    }
}