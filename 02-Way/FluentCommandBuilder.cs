using System.CommandLine;
using System.CommandLine.Invocation;
using System.Reflection;

namespace _02_Way;

public class FluentCommandBuilder : IFluentCommandBuilder
{
    private string? _name;
    private string? _description;
    private ICommandHandler? _commandHandler;
    private readonly List<Argument> _arguments = new();

    public IFluentCommandBuilder WithName(string name)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));
        return this;
    }

    public IFluentCommandBuilder WithDescription(string description)
    {
        _description = description ?? throw new ArgumentNullException(nameof(description));
        return this;
    }

    public IFluentCommandBuilder WithArgument<T>(Action<IFluentArgumentBuilder<T>> configureArguments)
    {
        var argumentBuilder = new FluentArgumentBuilder<T>();
        configureArguments(argumentBuilder);
        var argument = argumentBuilder.Build();
        _arguments.Add(argument);
        return this;
    }

    public IFluentCommandBuilder WithHandler(string methodName)
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static;
        var method = typeof(Program).GetMethod(methodName, flags);
        return WithHandler(CommandHandler.Create(method!));
    }

    public IFluentCommandBuilder WithHandler<T>(Action<T> action)
    {
        return WithHandler(CommandHandler.Create(action));
    }

    public IFluentCommandBuilder WithHandler(ICommandHandler commandHandler)
    {
        _commandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
        return this;
    }

    public IFluentCommand Build()
    {
        var command = new FluentCommand(_name!, _description)
        {
            Handler = _commandHandler
        };

        command.AddArguments(_arguments);
        
        return command;
    }
}