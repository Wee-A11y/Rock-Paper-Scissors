namespace RockPaperScissors
{
    public class ChoiceParser : IChoiceParser
    {
        public int TryParseInput(string input)
        {
            if (!int.TryParse(input, out var choice))
            {
                throw new IOException("Please keep selections between '1', '2', and '3'.");
            }

            return choice;
        }
    }
}
