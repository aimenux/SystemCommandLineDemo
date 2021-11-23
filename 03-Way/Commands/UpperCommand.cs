namespace _03_Way.Commands;

public class UpperCommand : AbstractCommand
{
    public UpperCommand() : base("upper")
    {
        AddHandler<string>(ToUpper);
    }

    private static void ToUpper(string input) => Console.WriteLine(input.ToUpper());
}