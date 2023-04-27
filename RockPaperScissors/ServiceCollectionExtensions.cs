using Microsoft.Extensions.DependencyInjection;

namespace RockPaperScissors;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGameServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IAlgorithm, Algorithm>()
            .AddTransient<ICalculateScore, CalculateScore>()
            .AddTransient<IGame, Game>();


    }

    public static IServiceCollection AddIOServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IUiFacade, UiFacade>()
            .AddTransient<IPlayAgain, PlayAgain>()
            .AddTransient<IDisplayWinner, DisplayWinner>();
    }
}