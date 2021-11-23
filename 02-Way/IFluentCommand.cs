using System.CommandLine;

namespace _02_Way;

public interface IFluentCommand : ICommand
{
}

public class FluentCommand : Command, IFluentCommand
{
    public FluentCommand(string name, string? description = null) : base(name, description)
    {
    }

    public void AddArguments(IEnumerable<Argument> arguments)
    {
        foreach (var argument in arguments)
        {
            AddArgument(argument);
        }
    }
}