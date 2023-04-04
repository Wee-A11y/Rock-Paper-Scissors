using FluentAssertions;
using HGEM.Testing;
using RockPaperScissors;
using Xunit;

namespace GameTest.Tests
{
    public class AlgorithmTest
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { ChoiceEnum.Paper, ChoiceEnum.Paper, Winner.Draw },
                new object[] { ChoiceEnum.Rock, ChoiceEnum.Rock, Winner.Draw },
                new object[] { ChoiceEnum.Scissors, ChoiceEnum.Scissors, Winner.Draw },

                new object[] { ChoiceEnum.Rock, ChoiceEnum.Paper, Winner.Choice2 },
                new object[] { ChoiceEnum.Scissors, ChoiceEnum.Rock, Winner.Choice2 },
                new object[] { ChoiceEnum.Paper, ChoiceEnum.Scissors, Winner.Choice2 },

                new object[] { ChoiceEnum.Paper, ChoiceEnum.Rock, Winner.Choice1 },
                new object[] { ChoiceEnum.Rock, ChoiceEnum.Scissors, Winner.Choice1 },
                new object[] { ChoiceEnum.Scissors, ChoiceEnum.Paper, Winner.Choice1 },
            };

        [Theory]
        [AutoMemberNSubstituteData(nameof(Data))]
        public void WHEN_Game_is_run_THEN_Decide_Winner(ChoiceEnum choice1, ChoiceEnum choice2, Winner expectedWinner, Algorithm sut)
        {
            sut.Run(choice1, choice2).Should().Be(expectedWinner);
        }
    }
}
