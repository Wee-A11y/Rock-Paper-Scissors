using AutoFixture.Xunit2;
using FluentAssertions;
using HGEM.Testing;
using NSubstitute;
using RockPaperScissors;
using Xunit;

namespace GameTest.Tests
{
    public class PlayerTests
    {
        [Theory]
        [AutoNSubstituteData()]

        internal void WHEN_the_player_makes_a_choice_THEN_the_choice_is_returned([Frozen] IChoiceFactory choice, IChoiceFactory sut)
        {
            choice.Choose().Returns(ChoiceEnum.Paper);
            sut.Choose().Should().Be(ChoiceEnum.Paper);
        }
        
    }
}
