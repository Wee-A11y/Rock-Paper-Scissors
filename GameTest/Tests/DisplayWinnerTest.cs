using FluentAssertions;
using HGEM.Testing;
using RockPaperScissors;
using Xunit;

namespace GameTest.Tests
{
    public class DisplayWinnerTest
    {

        [Theory]
        [AutoNSubstituteData]
        public void WHEN_Outcome_of_Game_is_draw_THEN_Display_no_Winner(DisplayWinner sut, IChoiceFactory choiceFactory, string? player1Name, string? player2Name)
        {
            sut
                .Display(Winner.Draw, new Player(player1Name, choiceFactory), new Player(player2Name, choiceFactory))
                .Should()
                .Be(DisplayWinner.NoWinner);
        }

        [Theory]
        [AutoNSubstituteData]
        public void WHEN_Outcome_of_Game_is_choice1_THEN_Display_player1(DisplayWinner sut, IChoiceFactory choiceFactory, string? player1Name, string? player2Name)
        {
            sut.Display(Winner.Choice1, new Player(player1Name, choiceFactory), new Player(player2Name, choiceFactory))
                .Should().
                Be(string.Format(DisplayWinner.PlayerWon, player1Name));
        }

        [Theory]
        [AutoNSubstituteData]
        public void WHEN_Outcome_of_Game_is_choice2_THEN_Display_player2(DisplayWinner sut, IChoiceFactory choiceFactory, string? player1Name, string? player2Name)
        {
            sut.Display(Winner.Choice2, new Player(player1Name, choiceFactory), new Player(player2Name, choiceFactory))
                .Should()
                .Be(string.Format(DisplayWinner.PlayerWon, player2Name));
        }

    }
}