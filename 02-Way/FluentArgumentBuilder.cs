using System.CommandLine;

namespace _02_Way;

public class FluentArgumentBuilder<T> : IFluentArgumentBuilder<T>
{
    private string? _name;
    private string? _description;
    private Func<T>? _getDefaultValue;

    public IFluentArgumentBuilder<T> WithName(string name)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));
        return this;
    }

    public IFluentArgumentBuilder<T> WithDescription(string description)
    {
        _description = description ?? throw new ArgumentNullException(nameof(description));
        return this;
    }

    public IFluentArgumentBuilder<T> WithDefaultValue(Func<T> getDefaultValue)
    {
        _getDefaultValue = getDefaultValue ?? throw new ArgumentNullException(nameof(getDefaultValue));
        return this;
    }

    public Argument<T> Build()
    {
        return _getDefaultValue is null 
            ? new Argument<T>(_name!, _description) 
            : new Argument<T>(_name!, _getDefaultValue, _description);
    }
}