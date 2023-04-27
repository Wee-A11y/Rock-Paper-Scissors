namespace RockPaperScissors
{
    public class CalculateScore : ICalculateScore
    {

        public int AddScore(Winner winner, Player player1, Player player2)
        {
            switch (winner)
            {
                case Winner.Player1Choice:
                    return ++player1.Score;
                case Winner.Player2Choice: 
                    return ++player2.Score;
                case Winner.Draw:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(winner), winner, null);
            }

            return 0;
        }

    }
}
