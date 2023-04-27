namespace RockPaperScissors;

public class Algorithm : IAlgorithm
{
    public Winner Run(ChoiceEnum Player1Choice, ChoiceEnum choice2)
    {
        //Compares the two choices and determines the winner
        switch (Player1Choice)
        {
            case ChoiceEnum.Rock when choice2 == ChoiceEnum.Scissors:
            case ChoiceEnum.Scissors when choice2 == ChoiceEnum.Paper:
            case ChoiceEnum.Paper when choice2 == ChoiceEnum.Rock:
                return Winner.Player1Choice;
            case ChoiceEnum.Paper when choice2 == ChoiceEnum.Scissors:
            case ChoiceEnum.Rock when choice2 == ChoiceEnum.Paper:
            case ChoiceEnum.Scissors when choice2 == ChoiceEnum.Rock:
                return Winner.Player2Choice;
            default:
                return Winner.Draw;
        }
    }
}