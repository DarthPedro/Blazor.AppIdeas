using System;

namespace Blazor.AppIdeas.Converters.ViewModels
{
    public class BinaryDecimalConverter
    {
        public string Binary { get; set; }

        public string Decimal { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorVisibility
        {
            get => string.IsNullOrEmpty(ErrorMessage) ? "none" : "normal";
        }

        public void ConvertDecimal()
        {
            try
            {
                ErrorMessage = string.Empty;
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
                ErrorMessage = string.Empty;
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
