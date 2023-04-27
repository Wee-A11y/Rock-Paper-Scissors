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

                new object[] { ChoiceEnum.Rock, ChoiceEnum.Paper, Winner.Player2Choice },
                new object[] { ChoiceEnum.Scissors, ChoiceEnum.Rock, Winner.Player2Choice },
                new object[] { ChoiceEnum.Paper, ChoiceEnum.Scissors, Winner.Player2Choice },
                
                new object[] { ChoiceEnum.Paper, ChoiceEnum.Rock, Winner.Player1Choice },
                new object[] { ChoiceEnum.Rock, ChoiceEnum.Scissors, Winner.Player1Choice },
                new object[] { ChoiceEnum.Scissors, ChoiceEnum.Paper, Winner.Player1Choice },
            };

        [Theory]
        [AutoMemberNSubstituteData(nameof(Data))]
        public void WHEN_Game_is_run_THEN_Decide_Winner(ChoiceEnum Player1Choice, ChoiceEnum choice2, Winner expectedWinner, Algorithm sut)
        {
            sut.Run(Player1Choice, choice2).Should().Be(expectedWinner);
        }
    }
}
