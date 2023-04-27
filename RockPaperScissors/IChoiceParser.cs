namespace RockPaperScissors;

public interface IChoiceParser
{
    bool TryParseInput(string input);
    int ParseInput(string input);
}