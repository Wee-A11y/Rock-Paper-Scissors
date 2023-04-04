namespace RockPaperScissors;

public class ChoiceDictProvider
{

    private static readonly Dictionary<int, ChoiceEnum> _choiceDictionary = new()
    {
        { 1, ChoiceEnum.Rock},
        { 2, ChoiceEnum.Paper },
        { 3, ChoiceEnum.Scissors }
    };

    public Dictionary<int, ChoiceEnum> ChoiceDictionary => _choiceDictionary;
}