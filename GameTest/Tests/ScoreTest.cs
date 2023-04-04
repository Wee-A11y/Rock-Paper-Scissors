using FluentAssertions;
using HGEM.Testing;
using RockPaperScissors;
using Xunit;

namespace GameTest.Tests;

public class CalculateScoreTest
{
    [Theory]
    [AutoNSubstituteData]
    public void WHEN_player1_wins_the_round_THEN_Add_score(CalculateScore sut, Winner winner, Score score)
    {

        var initialPlayer1Score = score.Player1Score;
        var expectedPlayer1Score = initialPlayer1Score;

        sut.AddScore(winner);

        score.Player1Score.Should().Be(expectedPlayer1Score);
    }

    [Theory]
    [AutoNSubstituteData]
    public void WHEN_player2_wins_the_round_THEN_Add_point_to_score(CalculateScore sut, Winner winner, Score score)
    {

        var initialPlayer2Score = score.Player2Score;
        var expectedPlayer2Score = initialPlayer2Score;

        sut.AddScore(winner);

        score.Player2Score.Should().Be(expectedPlayer2Score);
    }

}