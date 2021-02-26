using Blazor.AppIdeas.Converters.Models;
using System;

namespace Blazor.AppIdeas.Converters.ViewModels
{
    public class NumberConverterViewModel
    {
        public string EntryValue { get; set; }

        public NumberSystem EntryNumberSystem { get; set; } = NumberSystem.Binary;

        public string ResultValue { get; set; }

        public NumberSystem ResultNumberSystem { get; set; } = NumberSystem.Decimal;

        public string ErrorMessage { get; private set; }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public void Convert()
        {
            try
            {
                ErrorMessage = null;
                if (string.IsNullOrEmpty(EntryValue)) throw new FormatException();

                var valueAsInt = NumberConversionStrategy.ConvertFrom(EntryValue, EntryNumberSystem);
                ResultValue = NumberConversionStrategy.ConvertTo(valueAsInt, ResultNumberSystem);
            }
            catch
            {
                ErrorMessage = NumberConversionStrategy.GetNumberSystemErrorMessage(EntryNumberSystem);
            }
        }
    }
}
