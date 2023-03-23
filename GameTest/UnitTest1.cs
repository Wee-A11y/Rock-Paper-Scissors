using FluentAssertions;
using HGEM.Testing;
using NSubstitute;
using RockPaperScissors;

namespace GameTest
{
    public class UnitTest1
    {
        //public static IEnumerable<object[]> Data =>
        //    new List<object[]>
        //    {
        //        new object[] { ChoiceEnum.Paper, ChoiceEnum.Paper, Winner.Draw },
        //        new object[] { ChoiceEnum.Rock, ChoiceEnum.Rock, Winner.Draw },
        //        new object[] { ChoiceEnum.Scissors, ChoiceEnum.Scissors, Winner.Draw },

        //        new object[] { ChoiceEnum.Rock, ChoiceEnum.Paper, Winner.Choice2 },
        //        new object[] { ChoiceEnum.Scissors, ChoiceEnum.Rock, Winner.Choice2 },
        //        new object[] { ChoiceEnum.Paper, ChoiceEnum.Scissors, Winner.Choice2 },

        //        new object[] { ChoiceEnum.Paper, ChoiceEnum.Rock, Winner.Choice1 },
        //        new object[] { ChoiceEnum.Rock, ChoiceEnum.Scissors, Winner.Choice1 },
        //        new object[] { ChoiceEnum.Scissors, ChoiceEnum.Paper, Winner.Choice1 },
        //    };

        [Theory]
        [AutoNSubstituteData()]
        public void Score(Player choice1, Player choice2, Winner winner)
        {
            var sut = new Algorithm();
            sut.Run(choice1, choice2).Should().Be(winner);
        }


        [Theory]
        [AutoNSubstituteData()]
        public void WHEN_computer_choiceTHEN(ComputerChoiceFactory sut)
        {
            sut.Choose().Should().BeOneOf("Rock", "Paper", "Scissors");
        }


        [Theory]
        [AutoNSubstituteData()]
        public void WHEN_Outcome_of_Game_Decided_THEN_Display_Winner(DisplayWinner sut, IChoiceFactory choiceFactory, string player1Name, string player2Name)
        {
            sut.Display(Winner.Draw, new Player(player1Name, choiceFactory), new Player(player2Name, choiceFactory)).Should().Be(DisplayWinner.NoWinner);
            sut.Display(Winner.Choice1, new Player(player1Name, choiceFactory), new Player(player2Name, choiceFactory)).Should().Be(string.Format(DisplayWinner.PlayerWon, player1Name));
            sut.Display(Winner.Choice2, new Player(player1Name, choiceFactory), new Player(player2Name, choiceFactory)).Should().Be(string.Format(DisplayWinner.PlayerWon, player2Name));
        }

        //    [Theory]
        //    [AutoNSubstituteData()]
        //    public void When_point_is_won_THEN_score_should_be_displayed(Score sut, IChoiceFactory choiceFactory, Winner winner, Player player1, string player2, int player1Score)
        //    {
        //        var player1 = new Player("Tim", choiceFactory)
        //        {
        //            Score = 2
        //        };
        //        var player2 = new Player("Alice", choiceFactory)
        //        {
        //            Score = 4
        //        };


        //        sut.AddScore;


        //    }

    }
}