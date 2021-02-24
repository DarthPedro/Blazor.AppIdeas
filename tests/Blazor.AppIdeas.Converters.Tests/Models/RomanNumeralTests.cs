using Blazor.AppIdeas.Converters.Models;
using System;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Models
{
    public class RomanNumeralTests
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("V", 5)]
        [InlineData("x", 10)]
        [InlineData("l", 50)]
        [InlineData("C", 100)]
        [InlineData("D", 500)]
        [InlineData("M", 1000)]
        [InlineData("", 0)]
        [InlineData("IV", 4)]
        [InlineData("XI", 11)]
        [InlineData("XLII", 42)]
        [InlineData("MMXXi", 2021)]
        [InlineData("MCMLXX", 1970)]
        [InlineData("MMMCMXCIX", 3999)]
        public void ToIntConversions(string romanValue, int expectedResult)
        {
            // arrange
            var roman = new RomanNumeral(romanValue);

            // act
            var result = roman.ToInt();

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        [InlineData(0, "")]
        [InlineData(4, "IV")]
        [InlineData(11, "XI")]
        [InlineData(42, "XLII")]
        [InlineData(2021, "MMXXI")]
        [InlineData(1970, "MCMLXX")]
        [InlineData(3999, "MMMCMXCIX")]
        public void FromDecimalConversions(int decimalValue, string expectedResult)
        {
            // arrange

            // act
            var roman = RomanNumeral.FromDecimal(decimalValue);

            // assert
            Assert.Equal(expectedResult, roman.Value);
        }

        [Fact]
        public void Create_WithNullNumber()
        {
            // arrange

            // act - assert
            Assert.Throws<ArgumentNullException>(() => new RomanNumeral(null));
        }

        [Fact]
        public void FromDecimal_WithNegativeValue()
        {
            // arrange

            // act - assert
            Assert.Throws<FormatException>(() => RomanNumeral.FromDecimal(-2));
        }
    }
}
