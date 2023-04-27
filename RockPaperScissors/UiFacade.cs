namespace RockPaperScissors;

public class UiFacade : IUiFacade
{
    public void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }

}