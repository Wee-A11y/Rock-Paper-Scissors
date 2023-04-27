using FluentAssertions;
using HGEM.Testing;
using RockPaperScissors;
using Xunit;

namespace GameTest.Tests
{
    public class ChoiceParserTests
    {
        [Theory] 
        [InlineAutoNSubstituteData("1", true)]
        [InlineAutoNSubstituteData("2", true)]
        [InlineAutoNSubstituteData("3", true)]

        internal void WHEN_the_input_is_valid_THEN_returns_success(string value, bool expectedValue, ChoiceParser sut)
        {
            sut.TryParseInput(value).Should().Be(expectedValue);
        }

        [Theory]
        [InlineAutoNSubstituteData("0", false)]
        [InlineAutoNSubstituteData("4", false)]
        [InlineAutoNSubstituteData("Fred", false)]
        internal void WHEN_the_input_is_invalid_THEN_(string value, bool expectedValue, ChoiceParser sut)
        {
            sut.TryParseInput(value).Should().Be(expectedValue);
        }
    }
}
