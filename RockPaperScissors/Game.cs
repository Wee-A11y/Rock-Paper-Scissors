//using System.Linq.Expressions;
//using System.Threading.Channels;

//namespace RockPaperScissors
//{
//    //public interface IGame
//    //{
//    //}

//    public class Game //: IGame
//    {
//        private readonly IAlgorithm _algorithm;
//        private readonly IDisplayWinner _displayWinner;

//        public Game(IAlgorithm algorithm, IDisplayWinner displayWinner)
//        {
//            _algorithm = algorithm;
//            _displayWinner = displayWinner;
//        }

//        public void Play(Player player1, Player player2)
//        {
//            do
//            {
//                //Player makes a choice and the choices are displayed beside the players name
//                Console.WriteLine("***----- NEW GAME ----***");
//                Console.WriteLine();
//                var choice1 = player1.Choose();
//                Console.WriteLine();
//                Console.WriteLine($"{player1.Name} played.. {choice1}");

//                var choice2 = player2.Choose();
//                Console.WriteLine($"{player2.Name} played.. {choice2}");
//                Console.WriteLine();


//                //Two choices are compared and the winner is displayed
//                var winner = _algorithm.Run(choice1, choice2);
//                Console.WriteLine(_displayWinner.Display(winner, player1, player2));
//                Console.WriteLine();
//                Score displayScore = new Score();
//                displayScore.AddScore(winner, player1, player2);
//                Console.WriteLine($"{player1.Name} score: {player1.Score}");
//                Console.WriteLine($"{player2.Name} score: {player2.Score}");

//                Console.WriteLine();
//            } while (PlayAgain.Prompt());

//            Console.WriteLine("Thank you for playing");
//        }
//    }

//    public interface IDisplayWinner
//    {
//        string Display(Winner winner, Player player1, Player player2);
//    }

//    public class DisplayWinner : IDisplayWinner
//    {
//        //Formats string for if a player wins or if there is a draw
//        public const string PlayerWon = "{0} won";
//        public const string NoWinner = "It's a draw! No winner";

//        public string Display(Winner winner, Player player1, Player player2)
//        {
//            switch (winner)
//            {
//                case Winner.Choice1:
//                    return string.Format(PlayerWon, player1.Name);
//                case Winner.Choice2:
//                    return string.Format(PlayerWon, player2.Name);
//                case Winner.Draw:
//                default:
//                    return NoWinner;
//            }
//        }

//    }

//    public interface IChoiceFactory
//    {
//        ChoiceEnum Choose();
//    }


//    public class PersonChoiceFactory : IChoiceFactory
//    {
//        public ChoiceEnum Choose()
//        {
//            try
//            {
//                Console.WriteLine(
//                    $"Please enter your choice {string.Join(',', Enum.GetValues<ChoiceEnum>().ToList())}");
//                var value = Console.ReadLine();
//                if (value != null) return Enum.Parse<ChoiceEnum>(value);
//            }
//            catch (Exception)
//            {
//                Console.WriteLine();
//                Console.WriteLine("Input invalid");
//                PlayAgain.Prompt();
//                return Choose();
//            }

//            throw new InvalidOperationException();
//        }
//    }

//    public class ComputerChoiceFactory : IChoiceFactory
//    {
//        private readonly List<ChoiceEnum> _choices = Enum.GetValues<ChoiceEnum>().ToList();

//        public ChoiceEnum Choose()
//        {
//            var random = new Random();
//            return _choices[random.Next(0, _choices.Count)];
//        }
//    }

//    public class Player
//    {
//        private readonly IChoiceFactory _choiceFactory;
//        public string Name { get; private set; }

//        public int Score;
//        private Player _player1;

//        public Player(string name, IChoiceFactory choiceFactory)
//        {
//            _choiceFactory = choiceFactory;
//            Name = name;
//            Score = 0;
//        }

//        public Player(Player player1, IChoiceFactory choiceFactory)
//        {
//            this._player1 = player1;
//            this._choiceFactory = choiceFactory;
//        }

//        public ChoiceEnum Choose()
//        {
//            return _choiceFactory.Choose();
//        }
//    }

//    public enum Winner
//    {
//        Choice1,
//        Choice2,
//        Draw
//    }

//    public enum ChoiceEnum
//    {
//        Rock =1,
//        Paper,
//        Scissors
//    }

//    public interface IAlgorithm
//    {
//        public Winner Run(ChoiceEnum choice1, ChoiceEnum choice2);
//    }

//    public class Algorithm : IAlgorithm
//    {
//        public Winner Run(ChoiceEnum choiceEnum1, ChoiceEnum choiceEnum2)
//        {

//            //Compares the two choices and determines the winner

//            switch (choiceEnum1)
//            {
//                case ChoiceEnum.Paper when choiceEnum2 == ChoiceEnum.Rock:
//                case ChoiceEnum.Rock when choiceEnum2 == ChoiceEnum.Scissors:
//                case ChoiceEnum.Scissors when choiceEnum2 == ChoiceEnum.Paper:
//                    return Winner.Choice1;
//                case ChoiceEnum.Scissors when choiceEnum2 == ChoiceEnum.Rock:
//                case ChoiceEnum.Paper when choiceEnum2 == ChoiceEnum.Scissors:
//                case ChoiceEnum.Rock when choiceEnum2 == ChoiceEnum.Paper:
//                    return Winner.Choice2;
//                default:
//                    return Winner.Draw;
//            }
//        }
//    }

//    public class Score
//    {
//        public void AddScore(Winner winner, Player player1, Player player2)
//        {
//            switch (winner)
//            {
//                case Winner.Choice1:
//                    player1.Score++;
//                    break;
//                case Winner.Choice2:
//                    player2.Score++;
//                    break;
//                case Winner.Draw:
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException(nameof(winner), winner, null);
//            }
//        }

//    }

//    public class PlayAgain
//    {
//        public static bool Prompt()
//        {
//            Console.WriteLine("Play again (y/n): ");
//            var check = Console.ReadKey();
//            Console.WriteLine();
//            Console.WriteLine();
//            var keepPlaying = check.Key.ToString().ToLower() == "y";
//            return keepPlaying;
//        }

//    }
//}

