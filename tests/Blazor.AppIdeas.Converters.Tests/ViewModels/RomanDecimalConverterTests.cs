using Blazor.AppIdeas.Converters.ViewModels;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.ViewModels
{
    public class RomanDecimalConverterTests
    {
        private const string romanErrorMessage = "Roman numerals only support the following characters: I, V, X, L, C, D, M.";
        private const string decimalErrorMessage = "Decimal must be a valid number with only digits 0-9.";

        [Fact]
        public void Construction()
        {
            // arrange

            // act
            var converter = new RomanDecimalConverter();

            // assert
            Assert.NotNull(converter);
            Assert.Null(converter.RomanText);
            Assert.Null(converter.Decimal);
            Assert.Null(converter.ErrorMessage);
            Assert.Equal("none", converter.ErrorDisplay);
        }

        [Theory]
        [InlineData("V", "5", null, "none")]
        [InlineData("CCXVIII", "218", null, "none")]
        [InlineData(null, null, romanErrorMessage, "normal")]
        [InlineData("CCQVI", null, romanErrorMessage, "normal")]
        public void ConvertDecimal_WithRomanString(
            string initialRoman, string expectedDecimal, string expectedErrorMessage, string expectedErrorDisplay)
        {
            // arrange
            var converter = new RomanDecimalConverter
            {
                RomanText = initialRoman
            };

            // act
            converter.ConvertDecimal();

            // assert
            Assert.Equal(expectedDecimal, converter.Decimal);
            Assert.Equal(expectedErrorMessage, converter.ErrorMessage);
            Assert.Equal(expectedErrorDisplay, converter.ErrorDisplay);
        }

        [Theory]
        [InlineData("5", "V", null, "none")]
        [InlineData("186", "CLXXXVI", null, "none")]
        [InlineData("", null, decimalErrorMessage, "normal")]
        [InlineData("102l", null, decimalErrorMessage, "normal")]
        public void ConvertBinary_WithDecimalString(
            string initialDecimal, string expectedRoman, string expectedErrorMessage, string expectedErrorDisplay)
        {
            // arrange
            var converter = new RomanDecimalConverter
            {
                Decimal = initialDecimal
            };

            // act
            converter.ConvertRoman();

            // assert
            Assert.Equal(expectedRoman, converter.RomanText);
            Assert.Equal(expectedErrorMessage, converter.ErrorMessage);
            Assert.Equal(expectedErrorDisplay, converter.ErrorDisplay);
        }
    }
}
