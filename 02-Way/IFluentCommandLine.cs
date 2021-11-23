namespace _02_Way;

public interface IFluentCommandLine
{
    Task<int> RunAsync(string[] args);
}