namespace RockPaperScissors;

public class PersonChoiceFactory : IChoiceFactory
{
    private readonly IChoiceParser _choiceParser;
    private readonly IUiFacade _uiFacade;
    private readonly ChoiceDictProvider _choiceDict = new();
    private const int NumberOfAttempts = 3;

    public PersonChoiceFactory(IChoiceParser choiceParser, IUiFacade uiFacade)
    {
        _choiceParser = choiceParser;
        _uiFacade = uiFacade;
    }

    public ChoiceEnum Choose()
    {
        var userAttempts = 0;
        bool playerChoiceValid;
        string input;
        do
        {
            _uiFacade.WriteMessage("Choose an option: 1.Rock, 2.Paper, 3.Scissors, 4.Exit");
            input = _uiFacade.ReadLine();
            
            playerChoiceValid = _choiceParser.TryParseInput(input);
            userAttempts++;
        } while (userAttempts < NumberOfAttempts && playerChoiceValid == false);

        if (playerChoiceValid)
        {
            var playChoice = _choiceParser.ParseInput(input);
            return _choiceDict.ChoiceDictionary[playChoice];
        }

        throw new ArgumentOutOfRangeException($"Selection is incorrect");
    }
}