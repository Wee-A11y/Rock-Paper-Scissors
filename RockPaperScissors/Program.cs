namespace RockPaperScissors
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var player1 = new Player("Allison", new PersonChoiceFactory());
            var player2 = new Player("Computer", new ComputerChoiceFactory());

            var game = new Game(new Algorithm(), new DisplayWinner(), new MessageWriter());
            game.Play(player1, player2);

            //    ;
            //var player1 = Console.ReadLine();
            //var choices = new string[3] { "rock", "paper", "scissors" };
            //var randomChoice = new Random();
            //var n = randomChoice.Next(0, 2);
            //var choice = choices[n];

            //var keepPlaying = true;

            //var playerPoints = 0;
            //var computerPoints = 0;

            //GamePlay(keepPlaying, playerPoints, computerPoints);

        }


        private static void GamePlay(bool keepPlaying, int playerPoints, int computerPoints)
        {
            while (keepPlaying)
            {
                Console.WriteLine("****----NEW GAME----****");
                Console.WriteLine();
                Console.WriteLine("Rock, Paper or Scissors: ");
                var player1 = Console.ReadLine();
                var choices = new string[3] { "rock", "paper", "scissors" };
                var randomChoice = new Random();
                var n = randomChoice.Next(0, 3);
                var choice = choices[n];

                if (player1 == "rock" && choice == "paper" || player1 == "paper" && choice == "scissors" || player1 == "scissors" && choice == "rock")
                {
                    Console.WriteLine($"You play.... {player1}");
                    Console.WriteLine($"Computer plays.. {choice}");
                    Console.WriteLine();
                    Console.WriteLine("Computer Wins!");
                    Console.WriteLine();
                    computerPoints++;

                }
                else if (player1 == "scissors" && choice == "paper" || player1 == "rock" && choice == "scissors" || player1 == "paper" && choice == "rock")
                {
                    Console.WriteLine($"You play.... {player1}");
                    Console.WriteLine($"Computer plays.. {choice}");
                    Console.WriteLine();
                    Console.WriteLine("You Win!");
                    Console.WriteLine();
                    playerPoints++;
                }
                else if (player1 == choice)
                {
                    Console.WriteLine($"You play.... {player1}");
                    Console.WriteLine($"Computer plays.. {choice}");
                    Console.WriteLine();
                    Console.WriteLine("It's a draw!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Sorry you have entered an invalid response");
                    Console.WriteLine();
                }

                Console.WriteLine(computerPoints == 1 ? $"The computer has {computerPoints} point" : $"The computer has {computerPoints} points");
                Console.WriteLine(playerPoints == 1 ? $"You have {playerPoints} point" : $"You have {playerPoints} points");
                Console.WriteLine();
                Console.WriteLine("Do you want to play again? (y/n)");
                var check = Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                keepPlaying = check.Key.ToString().ToLower() == "y";
            }
        }

    }
}

