using HGEM.Testing;
using RockPaperScissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace GameTest.Tests
{
    public class UiFacadeTests
    {
        [Theory]
        [InlineAutoNSubstituteData("Hello player")]

        internal void WHEN_the_message_is_written_THEN_it_is_displayed(string message, UiFacade sut)
        {
            sut.WriteMessage(message);
        }

        [Theory]
        [InlineAutoNSubstituteData("Hello player")]

        internal void WHEN_the_readLine_is_called_THEN_it_is_displayed(string message, UiFacade sut)
        {
            sut.ReadLine().Should().Be(message);
        }
    }
}
