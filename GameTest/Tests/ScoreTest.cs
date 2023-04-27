using FluentAssertions;
using HGEM.Testing;
using RockPaperScissors;
using Xunit;

namespace GameTest.Tests;

public class CalculateScoreTest
{
    [Theory]
    [AutoNSubstituteData]
    public void WHEN_player1_wins_the_round_THEN_Add_score(CalculateScore sut, Winner winner, Player player1, Player player2)
    {

        var initialPlayer1Score = player1.Score;
        var expectedPlayer1Score = initialPlayer1Score;

        sut.AddScore(winner, player1, player2);

        player1.Score.Should().Be(expectedPlayer1Score);
    }

    [Theory]
    [AutoNSubstituteData]
    public void WHEN_player2_wins_the_round_THEN_Add_point_to_score(CalculateScore sut, Winner winner, Player player1, Player player2)
    {

        var initialPlayer2Score = player2.Score;
        var expectedPlayer2Score = initialPlayer2Score;

        sut.AddScore(winner, player1, player2);

        player2.Score.Should().Be(expectedPlayer2Score);
    }

}