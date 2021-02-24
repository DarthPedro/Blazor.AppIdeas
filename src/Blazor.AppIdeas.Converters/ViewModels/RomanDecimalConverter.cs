using Blazor.AppIdeas.Converters.Models;
using System;

namespace Blazor.AppIdeas.Converters.ViewModels
{
    public class RomanDecimalConverter
    {
        public string RomanText { get; set; }

        public string Decimal { get; set; }

        public string ErrorMessage { get; private set; }

        public string ErrorDisplay => string.IsNullOrEmpty(ErrorMessage) ? "none" : "normal";

        public void ConvertDecimal()
        {
            try
            {
                ErrorMessage = null;
                if (RomanText is null) throw new FormatException();

                var roman = new RomanNumeral(RomanText);
                Decimal = roman.ToInt().ToString();
            }
            catch
            {
                ErrorMessage = "Roman numerals only support the following characters: I, V, X, L, C, D, M.";
            }
        }

        public void ConvertRoman()
        {
            try
            {
                ErrorMessage = null;
                if (string.IsNullOrEmpty(Decimal)) throw new FormatException();

                var number = Convert.ToInt32(Decimal);
                var roman = RomanNumeral.FromDecimal(number);
                RomanText = roman.Value;
            }
            catch
            {
                ErrorMessage = "Decimal must be a valid number with only digits 0-9.";
            }
        }
    }
}
