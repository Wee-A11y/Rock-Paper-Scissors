using FluentAssertions;
using HGEM.Testing;
using RockPaperScissors;
using Xunit;


namespace GameTest.Tests;

public class ComputerChoiceTest
{
    [Theory]
    [AutoNSubstituteData]
    public void WHEN_computer_choice_is_made_THEN_assign_computer_choice(ComputerChoiceFactory sut)
    {
        sut.Choose().Should().BeOneOf(ChoiceEnum.Paper, ChoiceEnum.Rock, ChoiceEnum.Scissors);
    }
}