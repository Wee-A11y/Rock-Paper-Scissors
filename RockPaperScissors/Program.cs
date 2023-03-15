namespace RockPaperScissors
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var keepPlaying = true;

            var playerPoints = 0;
            var computerPoints = 0;

            while (keepPlaying)
            {
                Console.WriteLine("****----NEW GAME----****");
                Console.WriteLine();
                Console.WriteLine("Rock, Paper or Scissors: ");
                var player1 = Console.ReadLine();
                var choices = new string[3] { "rock", "paper", "scissors" };
                var randomChoice = new Random();
                var n = randomChoice.Next(0, 3);

                if (player1 == "rock" && choices[n] == "paper" || player1 == "paper" && choices[n] == "scissors" || player1 == "scissors" && choices[n] == "rock")
                {
                    Console.WriteLine($"You play.... {player1}");
                    Console.WriteLine($"Computer plays.. {choices[n]}");
                    Console.WriteLine();
                    Console.WriteLine("Computer Wins!");
                    Console.WriteLine();
                    computerPoints++;

                }
                else if (player1 == "scissors" && choices[n] == "paper" || player1 == "rock" && choices[n] == "scissors" || player1 == "paper" && choices[n] == "rock")
                {
                    Console.WriteLine($"You play.... {player1}");
                    Console.WriteLine($"Computer plays.. {choices[n]}");
                    Console.WriteLine();
                    Console.WriteLine("You Win!");
                    Console.WriteLine();
                    playerPoints++;
                }
                else if (player1 == choices[n])
                {
                    Console.WriteLine($"You play.... {player1}");
                    Console.WriteLine($"Computer plays.. {choices[n]}");
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

