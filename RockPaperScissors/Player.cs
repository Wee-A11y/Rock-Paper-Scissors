namespace RockPaperScissors;

public class Player
{
    public int Score;
    private readonly IChoiceFactory _choiceFactory;
    public readonly string Name;

    public Player(string name, int score, IChoiceFactory choiceFactory)
    {
        Score = score;
        _choiceFactory = choiceFactory;
        Name = name;
    }

    public ChoiceEnum Choose()
    {
        return _choiceFactory.Choose();
    }
}