using System;
using System.Collections.Generic;

namespace Blazor.AppIdeas.Converters.Models
{
    public static class NumberConversionStrategy
    {
        private static readonly IDictionary<NumberSystem, int> _numberSytemBaseMapping =
            new Dictionary<NumberSystem, int>
            {
                { NumberSystem.Binary, 2 },
                { NumberSystem.Octal, 8 },
                { NumberSystem.Decimal, 10 },
                { NumberSystem.Hexadecimal, 16 },
            };

        private static readonly IDictionary<NumberSystem, string> _numberSystemErrorMessageMapping =
            new Dictionary<NumberSystem, string>
            {
                { NumberSystem.Binary, "Binary numbers only support digits: 0s and 1s." },
                { NumberSystem.Octal, "Octal numbers only support digits: 0-7." },
                { NumberSystem.Decimal, "Decimal numbers only support digits: 0-9." },
                { NumberSystem.Hexadecimal, "Hexadecimal numbers only support: digits 0-9 and characters A-F." },
                { NumberSystem.Roman, "Roman numerals only support the following characters: I, V, X, L, C, D, M." }
            };

        public static int ConvertFrom(string value, NumberSystem system)
        {
            return system switch
            {
                NumberSystem.Roman => new RomanNumeral(value).ToInt(),
                _ => Convert.ToInt32(value, _numberSytemBaseMapping[system]),
            };
        }

        public static string ConvertTo(int value, NumberSystem system)
        {
            return system switch
            {
                NumberSystem.Roman => RomanNumeral.FromDecimal(value).Value,
                _ => Convert.ToString(value, _numberSytemBaseMapping[system]),
            };
        }

        public static string GetNumberSystemErrorMessage(NumberSystem system) =>
            _numberSystemErrorMessageMapping[system];
    }
}
