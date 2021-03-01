using System;
using System.Collections.Generic;

namespace Blazor.AppIdeas.Converters.Models
{
    public static class CoinCalculator
    {
        private static readonly IDictionary<CoinType, string> _coinTypeNameMap = new Dictionary<CoinType, string>
        {
            { CoinType.Penny, "Pennies (1¢)" },
            { CoinType.Nickel, "Nickels (5¢)" },
            { CoinType.Dime, "Dimes (10¢)" },
            { CoinType.Quarter, "Quarters (25¢)" },
        };

        public static IList<CoinResult> CalculateCoinBreakdown(int cents)
        {
            var result = new List<CoinResult>();
            if (cents < 0)
                return result;

            result.Add(CalculateCoinResult(cents, CoinType.Quarter));
            cents %= (int)CoinType.Quarter;

            result.Add(CalculateCoinResult(cents, CoinType.Dime));
            cents %= (int)CoinType.Dime;

            result.Add(CalculateCoinResult(cents, CoinType.Nickel));
            cents %= (int)CoinType.Nickel;

            result.Add(CalculateCoinResult(cents, CoinType.Penny));

            return result;
        }

        private static CoinResult CalculateCoinResult(int cents, CoinType type)
        {
            return new CoinResult(
                type,
                _coinTypeNameMap[type],
                CalculateCoinAmount(cents, type));
        }

        private static int CalculateCoinAmount(int cents, CoinType type) =>
            (int)Math.Floor(cents / (decimal)type);
    }
}
