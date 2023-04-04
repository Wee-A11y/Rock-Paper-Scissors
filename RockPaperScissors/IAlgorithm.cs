namespace RockPaperScissors;

public interface IAlgorithm
{
    Winner Run(ChoiceEnum choice1, ChoiceEnum choice2);
}