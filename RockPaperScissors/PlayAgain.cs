namespace RockPaperScissors;

public class PlayAgain
{
    public static bool Prompt(IMessageWriter messageWriter)
    {
        messageWriter.WriteMessage("Play again (y/n): ");
        var check = Console.ReadKey();
        messageWriter.WriteMessage("");
        messageWriter.WriteMessage("");
        var keepPlaying = check.Key.ToString().ToLower() == "y";
        return keepPlaying;
    }

}