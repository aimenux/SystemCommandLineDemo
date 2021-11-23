namespace _02_Way
{
    public interface IFluentCommandLineBuilder
    {
        IFluentCommandLineBuilder AddCommand(Action<IFluentCommandBuilder> configureCommand);
        IFluentCommandLine Build();
    }
}
