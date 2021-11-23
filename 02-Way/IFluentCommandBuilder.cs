using System.CommandLine.Invocation;

namespace _02_Way;

public interface IFluentCommandBuilder
{
    IFluentCommandBuilder WithName(string name);
    IFluentCommandBuilder WithDescription(string description);
    IFluentCommandBuilder WithArgument<T>(Action<IFluentArgumentBuilder<T>> configureArguments);
    IFluentCommandBuilder WithHandler(string methodName);
    IFluentCommandBuilder WithHandler<T>(Action<T> action);
    IFluentCommandBuilder WithHandler(ICommandHandler commandHandler);
    IFluentCommand Build();
}