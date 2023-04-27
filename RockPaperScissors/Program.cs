using Microsoft.Extensions.DependencyInjection;

namespace RockPaperScissors
{
    internal class Program
    {
        public static void Main()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection
                .AddGameServices()
                .AddIOServices();

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var player1 = new Player("Allison", 0,new PersonChoiceFactory(new ChoiceParser(), new UiFacade()));
            var player2 = new Player("Computer", 0,new ComputerChoiceFactory());

            var game = serviceProvider.GetRequiredService<IGame>();
            game.Play(player1, player2);
        }
    }
}

