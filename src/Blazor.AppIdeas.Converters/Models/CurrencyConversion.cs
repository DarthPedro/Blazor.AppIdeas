using System;

namespace Blazor.AppIdeas.Converters.Models
{
    public class CurrencyConversion
    {
        public CurrencyConversion(string convertFrom, string convertTo, decimal rate)
        {
            if (string.IsNullOrEmpty(convertFrom)) throw new ArgumentNullException(nameof(convertFrom));
            if (string.IsNullOrEmpty(convertTo)) throw new ArgumentNullException(nameof(convertTo));
            if (rate < 0M) throw new ArgumentOutOfRangeException(nameof(rate));

            ConvertFrom = convertFrom;
            ConvertTo = convertTo;
            Rate = rate;
        }
        public string ConvertFrom { get; }

        public string ConvertTo { get; }

        public decimal Rate { get; }
    }
}
