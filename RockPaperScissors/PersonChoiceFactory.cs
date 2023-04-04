namespace RockPaperScissors;

public class PersonChoiceFactory : IChoiceFactory
{
    private readonly IChoiceParser _choiceParser;
    private readonly ChoiceDictProvider _choiceDict = new ChoiceDictProvider();


    public PersonChoiceFactory(IChoiceParser choiceParser)
    {
        _choiceParser = choiceParser;
    }

    public ChoiceEnum Choose()
    {
        IChoiceFactory choiceTest = new PersonChoiceFactory(_choiceParser);
        Console.WriteLine("Choose an option 1.Rock, 2.Paper, 3.Scissors");
        var player1Choice = _choiceParser.TryParseInput(Console.ReadLine() ?? string.Empty);
        return _choiceDict.ChoiceDictionary.ContainsKey(player1Choice)
            ? _choiceDict.ChoiceDictionary[player1Choice]
            : ChoiceEnum.Paper;
    }
}