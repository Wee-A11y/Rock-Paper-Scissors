namespace RockPaperScissors;

public class ComputerChoiceFactory : IChoiceFactory
{
    private readonly ChoiceDictProvider _choiceDict = new();
    public ChoiceEnum Choose()
    {
        var random = new Random();
        var index = random.Next(_choiceDict.ChoiceDictionary.Count);
        return _choiceDict.ChoiceDictionary.Values.ElementAt(index);
    }
}