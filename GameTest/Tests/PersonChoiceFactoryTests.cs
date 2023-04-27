using AutoFixture.Xunit2;
using FluentAssertions;
using HGEM.Testing;
using NSubstitute;
using RockPaperScissors;
using Xunit;

namespace GameTest.Tests
{
    public class PersonChoiceFactoryTests
    {
        [Theory, AutoNSubstituteData()]
        internal void WHEN_person_makes_choice_THEN_the_correct_choice_is_returned([Frozen]IChoiceParser choiceParser, [Frozen]IUiFacade uiFacade, PersonChoiceFactory sut)
        {
            uiFacade.ReadLine().Returns("1");
            choiceParser.TryParseInput("1").Returns(true);

            sut.Choose().Should().Be(ChoiceEnum.Paper);
        }
    }
}
