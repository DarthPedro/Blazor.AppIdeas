using Blazor.AppIdeas.Converters.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.AppIdeas.Converters.ViewModels
{
    public class DollarCentsConverterViewModel
    {
        public string DollarValue { get; set; }

        public int Cents { get; set; }

        public IList<CoinResult> CoinResults { get; private set; } = new List<CoinResult>();

        public bool HasResults => CoinResults.Any();

        public string ErrorMessage { get; set; }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public void Convert()
        {
            try
            {
                ErrorMessage = null;
                if (string.IsNullOrEmpty(DollarValue)) throw new FormatException();

                Cents = CalculateCents(DollarValue);
                CoinResults = CoinCalculator.CalculateCoinBreakdown(Cents);
            }
            catch
            {
                ErrorMessage = "The dollar value must be a valid number between 0.00 and 1000.00.";
                CoinResults.Clear();
            }
        }

        private int CalculateCents(string dollarValue)
        {
            decimal dollar = System.Convert.ToDecimal(dollarValue);
            if (dollar < 0.0M || dollar > 1000.0M)
                throw new NotSupportedException();

            return (int)Math.Round(dollar * 100);
        }
    }
}
