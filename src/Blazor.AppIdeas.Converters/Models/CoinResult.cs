namespace Blazor.AppIdeas.Converters.Models
{
    public class CoinResult
    {
        public CoinResult(CoinType type, string name, int amount)
        {
            Type = type;
            DisplayName = name;
            Amount = amount;
        }

        public CoinType Type { get; private set; }

        public string DisplayName { get; private set; }

        public int Amount { get; private set; }
    }
}
