using System;
using System.Collections.Generic;
    
namespace Blazor.AppIdeas.Converters.Models
{
    /* 
     * Roman numeral conversion algorithms:
     *   Roman2Decimal: https://sites.google.com/site/computersciencesourcecode/conversion-algorithms/roman-to-decimal---algorithm-2
     *   Decimal2Roman: https://sites.google.com/site/computersciencesourcecode/conversion-algorithms/decimal-to-roman---algorithm-2
     */

    public class RomanNumeral
    {
        private static readonly IDictionary<string, int> _romanToDecimals = new Dictionary<string, int>
        {
            { "M", 1000 },
            { "D", 500 },
            { "C", 100 },
            { "L", 50 },
            { "X", 10 },
            { "V", 5 },
            { "I", 1 }
        };

        private static readonly int[] _decimalDivisors =
            new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        private static readonly string[] _romanEquivalents =
            new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public RomanNumeral(string number)
        {
            Value = number ?? throw new ArgumentNullException(nameof(number));
        }

        public string Value { get; private set; }

        public int ToInt()
        {
            int total = 0;
            int previousValue = 0;

            for (int ctr = Value.Length - 1; ctr >= 0; ctr--)
            {
                int currentValue = _romanToDecimals[Value[ctr].ToString().ToUpper()];
                if (currentValue < previousValue)
                {
                    total -= currentValue;
                }
                else
                {
                    total += currentValue;
                }

                previousValue = currentValue;
            }

            return total;
        }

        public static RomanNumeral FromDecimal(int number)
        {
            if (number < 0) throw new FormatException();
            string result = string.Empty;
            int currentPointer = 0;

            while(number > 0)
            {
                var count = number / _decimalDivisors[currentPointer];

                for (int i = 0; i < count; i++)
                {
                    result += _romanEquivalents[currentPointer];
                }

                number -= count * _decimalDivisors[currentPointer];
                currentPointer++;
            }

            return new RomanNumeral(result);
        }
    }
}
