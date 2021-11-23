using System.CommandLine;

namespace _02_Way;

public interface IFluentArgumentBuilder<T>
{
    IFluentArgumentBuilder<T> WithName(string name);
    IFluentArgumentBuilder<T> WithDescription(string description);
    IFluentArgumentBuilder<T> WithDefaultValue(Func<T> getDefaultValue);
    Argument<T> Build();
}