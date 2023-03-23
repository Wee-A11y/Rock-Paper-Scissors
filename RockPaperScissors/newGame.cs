namespace RockPaperScissors
{
    public class Game
    {
        private readonly IAlgorithm _algorithm;
        private readonly IDisplayWinner _displayWinner;
        private readonly IMessageWriter _messageWriter;

        public Game(IAlgorithm algorithm, IDisplayWinner displayWinner, IMessageWriter messageWriter)
        {
            _algorithm = algorithm;
            _displayWinner = displayWinner;
            _messageWriter = messageWriter;
        }

        public void Play(Player player1, Player player2)
        {
            do
            {
                //Player makes a choice and the choices are displayed beside the players name
                _messageWriter.WriteMessage("***----- NEW GAME ----***");
                _messageWriter.WriteMessage("");
                player1.ChosenOption = player1.Choose();
                _messageWriter.WriteMessage("");
                _messageWriter.WriteMessage($"{player1.Name} played.. {player1.ChosenOption}");

                player2.ChosenOption = player2.Choose();
                _messageWriter.WriteMessage($"{player2.Name} played.. {player2.ChosenOption}");
                _messageWriter.WriteMessage("");


                //Two choices are compared and the winner is displayed
                var winner = _algorithm.Run(player1, player2);
                _messageWriter.WriteMessage(_displayWinner.Display(winner, player1, player2));
                _messageWriter.WriteMessage("");
                Score displayScore = new Score();
                displayScore.AddScore(winner, player1, player2);
                _messageWriter.WriteMessage($"{player1.Name} score: {player1.Score}");
                _messageWriter.WriteMessage($"{player2.Name} score: {player2.Score}");

                _messageWriter.WriteMessage("");
            } while (PlayAgain.Prompt(_messageWriter));

            _messageWriter.WriteMessage("Thank you for playing");
        }
    }

    public interface IDisplayWinner
    {
        string Display(Winner winner, Player player1, Player player2);
    }

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

    public interface IChoiceFactory
    {
        string Choose();
    }


    public class PersonChoiceFactory : IChoiceFactory
    {
       private readonly ChoiceDictProvider _choiceDict = new ChoiceDictProvider();

        public string? Choose()
        {
            IChoiceFactory choiceTest = new PersonChoiceFactory();
            Console.WriteLine("Choose an option 1.Rock, 2.Paper, 3.Scissors");
            var player1Choice = int.Parse(Console.ReadLine());
            return _choiceDict.ChoiceDictionary.ContainsKey(player1Choice) ? _choiceDict.ChoiceDictionary[player1Choice] : null;
        }
    }

    public class ComputerChoiceFactory : IChoiceFactory
    {
        private readonly ChoiceDictProvider _choiceDict = new ChoiceDictProvider();
        private Random _random = new Random();

        public string Choose()
        {
            var random = new Random();
            var index = random.Next(_choiceDict.ChoiceDictionary.Count);
            return _choiceDict.ChoiceDictionary.Values.ElementAt(index);
        }
    }

    public class Player
    {
        private readonly IChoiceFactory _choiceFactory;
        public string Name { get; }
        public string ChosenOption { get; set; }

        public int Score;
        private Player _player1;

        public Player(string name, IChoiceFactory choiceFactory)
        {
            _choiceFactory = choiceFactory;
            Name = name;
            Score = 0;
        }

        public Player(Player player1, IChoiceFactory choiceFactory)
        {
            this._player1 = player1;
            this._choiceFactory = choiceFactory;
        }

        public string Choose()
        {
            ChosenOption = _choiceFactory.Choose();
            return ChosenOption;
        }

    }

    public enum Winner
    {
        Choice1,
        Choice2,
        Draw
    }

    public class ChoiceDictProvider
    {

        private static readonly Dictionary<int, string> _choiceDictionary = new()
        {
            { 1, "Rock" },
            { 2, "Paper" },
            { 3, "Scissors" }
        };

        public Dictionary<int, string> ChoiceDictionary => _choiceDictionary;
    }

    public interface IAlgorithm
    {
        Winner Run(Player player1Choice, Player player2Choice);
    }

    public class Algorithm : IAlgorithm
    {
        public Winner Run(Player player1Choice, Player player2Choice)
        {

            //Compares the two choices and determines the winner
            switch (player1Choice.ChosenOption)
            {
                case "Rock" when player2Choice.ChosenOption == "Scissors":
                case "Scissors" when player2Choice.ChosenOption == "Paper":
                case "Paper" when player2Choice.ChosenOption == "Rock":
                    return Winner.Choice1;
                case "Paper" when player2Choice.ChosenOption == "Scissors":
                case "Rock" when player2Choice.ChosenOption == "Paper":
                case "Scissors" when player2Choice.ChosenOption == "Rock":
                    return Winner.Choice2;
                default:
                    return Winner.Draw;
            }
        }
    }
    public class Score
    {
        public void AddScore(Winner winner, Player player1, Player player2)
        {
            switch (winner)
            {
                case Winner.Choice1:
                    player1.Score++;
                    break;
                case Winner.Choice2:
                    player2.Score++;
                    break;
                case Winner.Draw:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(winner), winner, null);
            }
        }

    }
  
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
    public interface IMessageWriter
    {
        void WriteMessage(string message);
    }

    public class MessageWriter : IMessageWriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

  


}
