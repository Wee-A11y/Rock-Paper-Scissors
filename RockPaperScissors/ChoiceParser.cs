using System.Linq;
using System.Xml;

namespace RockPaperScissors
{
    public class ChoiceParser : IChoiceParser
    {
        private readonly List<int> _validValues = new() { 1, 2, 3 };

        public bool TryParseInput(string input)
        {
            var valid = int.TryParse(input, out var value);
            if (!valid)
            {
                return valid;
            }

            if (value == 4)
            {
                Environment.Exit(0);
            }

            return _validValues.Any(x => x == value);
        }

        public int ParseInput(string input)
        {
            return int.Parse(input);
        }
    }
}
