namespace RockPaperScissors;

public interface ICalculateScore
{
    int AddScore(Winner winner, Player player1, Player player2);
}