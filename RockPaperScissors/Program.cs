namespace RockPaperScissors
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var player1 = new Player("Allison", new PersonChoiceFactory(new ChoiceParser()));
            var player2 = new Player("Computer", new ComputerChoiceFactory());

            var game = new Game(new Algorithm(), new DisplayWinner(), new MessageWriter(), new Score());
            game.Play(player1, player2);
        }
        
    }
}

