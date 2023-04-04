namespace RockPaperScissors;

public class Player
{
    private readonly IChoiceFactory _choiceFactory;
    public string? Name { get; set; }

    public Player(string? name, IChoiceFactory choiceFactory)
    {
        _choiceFactory = choiceFactory;
        Name = name;
    }

    public ChoiceEnum Choose()
    {
        return _choiceFactory.Choose();
    }

}