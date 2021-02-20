using System;

namespace Blazor.AppIdeas.Converters.ViewModels
{
    public class BinaryDecimalConverter
    {
        public string Binary { get; set; }

        public string Decimal { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorDisplay
        {
            get => string.IsNullOrEmpty(ErrorMessage) ? "none" : "normal";
        }

        public void ConvertDecimal()
        {
            try
            {
                ErrorMessage = null;
                if (string.IsNullOrEmpty(Binary)) throw new FormatException();

                Decimal = Convert.ToInt32(Binary, 2).ToString();
            }
            catch
            {
                ErrorMessage = "Binary must be a valid number with only 0s and 1s.";
            }
        }

        public void ConvertBinary()
        {
            try
            {
                ErrorMessage = null;
                if (string.IsNullOrEmpty(Decimal)) throw new FormatException();

                int number = Convert.ToInt32(Decimal);
                Binary = Convert.ToString(number, 2);
            }
            catch
            {
                ErrorMessage = "Decimal must be a valid number with only digits 0-9.";
            }
        }
    }
}
