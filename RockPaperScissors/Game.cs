namespace RockPaperScissors
{
    public class Game
    {
        private readonly IAlgorithm _algorithm;
        private readonly IDisplayWinner _displayWinner;
        private readonly IMessageWriter _messageWriter;
        private readonly CalculateScore _calculateScore;
        private readonly Score _score;

        public Game(IAlgorithm algorithm, IDisplayWinner displayWinner, IMessageWriter messageWriter, Score score)
        {
            _algorithm = algorithm;
            _displayWinner = displayWinner;
            _messageWriter = messageWriter;
            _calculateScore = new CalculateScore();
            _score = score;
        }


        public void Play(Player player1, Player player2)
        {
            _messageWriter.WriteMessage("Hello and welcome to the game");
            _messageWriter.WriteMessage("What is your name?");
            player1.Name = Console.ReadLine();

            do
            {
                try
                {
                    //Player makes a choice and the choices are displayed beside the players name
                    _messageWriter.WriteMessage("***----- NEW GAME ----***");
                    _messageWriter.WriteMessage("");

                    //Player 1 choice
                    var choice1 = player1.Choose();
                    _messageWriter.WriteMessage("");
                    _messageWriter.WriteMessage($"{player1.Name} played.. {choice1}");

                    //Player 2 choice
                    var choice2 = player2.Choose();
                    _messageWriter.WriteMessage($"{player2.Name} played.. {choice2}");
                    _messageWriter.WriteMessage("");

                    //Two choices are compared and the winner is displayed
                    var winner = _algorithm.Run(choice1, choice2);
                    _messageWriter.WriteMessage(_displayWinner.Display(winner, player1, player2));
                    _messageWriter.WriteMessage("");

                    //Update the score based on the winner
                    _calculateScore.AddScore(winner);
                    _score.Player1Score = _calculateScore.GetScore().Player1Score;
                    _score.Player2Score = _calculateScore.GetScore().Player2Score;

                    //Display the current score
                    _messageWriter.WriteMessage($"{player1.Name} score: {_score.Player1Score}");
                    _messageWriter.WriteMessage($"{player2.Name} score: {_score.Player2Score}");
                    _messageWriter.WriteMessage("");
                }
                catch (IOException e)
                {
                    _messageWriter.WriteMessage("Incorrect input, please choose 1, 2 or 3");
                }
            } while (PlayAgain.Prompt(_messageWriter));

            _messageWriter.WriteMessage("Thank you for playing");
        }
    }
}
