namespace RockPaperScissors;

public class PlayAgain : IPlayAgain
{
    private readonly IUiFacade _uiFacade;

    public PlayAgain(IUiFacade uiFacade)
    {
        _uiFacade = uiFacade;
    }

    public bool Prompt()
    {
        _uiFacade.WriteMessage("Play again (y/n): ");
        var check = Console.ReadKey();
        _uiFacade.WriteMessage("");
        _uiFacade.WriteMessage("");
        var keepPlaying = check.Key.ToString().ToLower() == "y";
        return keepPlaying;
    }

}