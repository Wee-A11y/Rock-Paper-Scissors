namespace RockPaperScissors;

public class DisplayWinner : IDisplayWinner
{
    public const string PlayerWon = "{0} won";
    public const string NoWinner = "It's a draw! No winner";

    public string Display(Winner winner, Player player1, Player player2)
    {
        switch (winner)
        {
            case Winner.Player1Choice:
                return string.Format(PlayerWon, player1.Name);
            case Winner.Player2Choice:
                return string.Format(PlayerWon, player2.Name);
            case Winner.Draw:
            default:
                return NoWinner;
        }
    }

}