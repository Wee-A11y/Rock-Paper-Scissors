namespace RockPaperScissors;

public interface IDisplayWinner
{
    string Display(Winner winner, Player player1, Player player2);
}