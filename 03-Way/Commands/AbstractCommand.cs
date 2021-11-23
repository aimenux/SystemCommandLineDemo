using System.CommandLine;
using System.CommandLine.Invocation;
using System.Reflection;

namespace _03_Way.Commands;

public abstract class AbstractCommand : Command
{
    protected AbstractCommand(string name) : base(name)
    {
    }

    public void AddHandler<T>(Action<T> action)
    {
        AddArgument(action);
        AddHandler(CommandHandler.Create(action));
    }

    private void AddArgument<T>(Action<T> action)
    {
        var methodInfo = action.GetMethodInfo();
        var argumentName = GetArgumentName(methodInfo);
        if (!string.IsNullOrWhiteSpace(argumentName))
        {
            AddArgument(new Argument<T>(argumentName));
        }
    }

    private void AddHandler(ICommandHandler handler)
    {
        Handler = handler;
    }

    private static string? GetArgumentName(MethodBase method, int index = 0)
    {
        var parameters = method.GetParameters();
        return parameters.Any() ? parameters[index].Name : null;
    }
}