namespace RockPaperScissors;

public interface IAlgorithm
{
    Winner Run(ChoiceEnum player1Choice, ChoiceEnum player2Choice);
}