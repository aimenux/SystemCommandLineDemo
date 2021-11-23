namespace _03_Way.Commands;

public class LowerCommand : AbstractCommand
{
    public LowerCommand() : base("lower")
    {
        AddHandler<string>(ToLower);
    }

    private static void ToLower(string input) => Console.WriteLine(input.ToLower());
}