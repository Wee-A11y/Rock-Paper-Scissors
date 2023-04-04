namespace RockPaperScissors
{
    public class CalculateScore
    {
        private readonly Score _score = new Score();

        public int AddScore(Winner winner)
        {
            switch (winner)
            {
                case Winner.Choice1:
                    return ++_score.Player1Score;
                case Winner.Choice2: 
                    return ++_score.Player2Score;
                case Winner.Draw:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(winner), winner, null);
            }

            return 0;
        }

        public Score GetScore()
        {
            return _score;
        }
    }
}
