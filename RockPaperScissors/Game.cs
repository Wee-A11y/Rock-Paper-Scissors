
namespace RockPaperScissors
{
    public class Game : IGame
    {
        private readonly IAlgorithm _algorithm;
        private readonly IDisplayWinner _displayWinner;
        private readonly IUiFacade _uiFacade;
        private readonly ICalculateScore _calculateScore;
        private readonly IPlayAgain _playAgain;

        public Game(IAlgorithm algorithm, IDisplayWinner displayWinner, IUiFacade uiFacade, IPlayAgain playAgain, ICalculateScore calculate)
        {
            _algorithm = algorithm;
            _displayWinner = displayWinner;
            _uiFacade = uiFacade;
            _calculateScore = calculate;
            _playAgain = playAgain;
        }

        public void Play(Player player1, Player player2)
        {
            _uiFacade.WriteMessage("Welcome to.. Rock Paper Scissors");

            do
            {
                _uiFacade.WriteMessage("***----- NEW GAME ----***");
                _uiFacade.WriteMessage("");
                
                var player1Choice = player1.Choose();
                _uiFacade.WriteMessage("");
                _uiFacade.WriteMessage($"{player1.Name} played.. {player1Choice}");

                var player2Choice = player2.Choose();
                _uiFacade.WriteMessage($"{player2.Name} played.. {player2Choice}");
                _uiFacade.WriteMessage("");

                var winner = _algorithm.Run(player1Choice, player2Choice);
                _uiFacade.WriteMessage(_displayWinner.Display(winner, player1, player2));
                _uiFacade.WriteMessage("");

                _calculateScore.AddScore(winner,player1, player2);

                _uiFacade.WriteMessage($"{player1.Name} score: {player1.Score}");
                _uiFacade.WriteMessage($"{player2.Name} score: {player2.Score}");
                _uiFacade.WriteMessage("");

            } while (_playAgain.Prompt());

            _uiFacade.WriteMessage("Thank you for playing");
        }
    }
}
