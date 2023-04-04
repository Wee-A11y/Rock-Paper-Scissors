namespace RockPaperScissors;

public class DisplayWinner : IDisplayWinner
{
    //Formats string for if a player wins or if there is a draw
    public const string PlayerWon = "{0} won";
    public const string NoWinner = "It's a draw! No winner";

    public string Display(Winner winner, Player player1, Player player2)
    {
        switch (winner)
        {
            case Winner.Choice1:
                return string.Format(PlayerWon, player1.Name);
            case Winner.Choice2:
                return string.Format(PlayerWon, player2.Name);
            case Winner.Draw:
            default:
                return NoWinner;
        }
    }

}