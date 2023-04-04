namespace RockPaperScissors;

public class Algorithm : IAlgorithm
{
    public Winner Run(ChoiceEnum choice1, ChoiceEnum choice2)
    {

        //Compares the two choices and determines the winner
        switch (choice1)
        {
            case ChoiceEnum.Rock when choice2 == ChoiceEnum.Scissors:
            case ChoiceEnum.Scissors when choice2 == ChoiceEnum.Paper:
            case ChoiceEnum.Paper when choice2 == ChoiceEnum.Rock:
                return Winner.Choice1;
            case ChoiceEnum.Paper when choice2 == ChoiceEnum.Scissors:
            case ChoiceEnum.Rock when choice2 == ChoiceEnum.Paper:
            case ChoiceEnum.Scissors when choice2 == ChoiceEnum.Rock:
                return Winner.Choice2;
            default:
                return Winner.Draw;
        }
    }
}