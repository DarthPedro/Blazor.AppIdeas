using Blazor.AppIdeas.Converters.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.ViewModels
{
    public class BinaryDecimalConverterTests
    {
        private const string binaryErrorMessage = "Binary must be a valid number with only 0s and 1s.";
        private const string decimalErrorMessage = "Decimal must be a valid number with only digits 0-9.";

        [Fact]
        public void Construction()
        {
            // arrange

            // act
            var converter = new BinaryDecimalConverter();

            // assert
            Assert.NotNull(converter);
            Assert.Null(converter.Binary);
            Assert.Null(converter.Decimal);
            Assert.Null(converter.ErrorMessage);
            Assert.Equal("none", converter.ErrorDisplay);
        }

        [Theory]
        [InlineData("101", "5", null, "none")]
        [InlineData("11011010", "218", null, "none")]
        [InlineData("", null, binaryErrorMessage, "normal")]
        [InlineData("102", null, binaryErrorMessage, "normal")]
        public void ConvertDecimal_WithBinaryString(
            string initialBinary, string expectedDecimal, string expectedErrorMessage, string expectedErrorDisplay)
        {
            // arrange
            var converter = new BinaryDecimalConverter
            {
                Binary = initialBinary
            };

            // act
            converter.ConvertDecimal();

            // assert
            Assert.Equal(expectedDecimal, converter.Decimal);
            Assert.Equal(expectedErrorMessage, converter.ErrorMessage);
            Assert.Equal(expectedErrorDisplay, converter.ErrorDisplay);
        }

        [Theory]
        [InlineData("5", "101", null, "none")]
        [InlineData("186", "10111010", null, "none")]
        [InlineData("", null, decimalErrorMessage, "normal")]
        [InlineData("102l", null, decimalErrorMessage, "normal")]
        public void ConvertBinary_WithDecimalString(
            string initialDecimal, string expectedBinary, string expectedErrorMessage, string expectedErrorDisplay)
        {
            // arrange
            var converter = new BinaryDecimalConverter
            {
                Decimal = initialDecimal
            };

            // act
            converter.ConvertBinary();

            // assert
            Assert.Equal(expectedBinary, converter.Binary);
            Assert.Equal(expectedErrorMessage, converter.ErrorMessage);
            Assert.Equal(expectedErrorDisplay, converter.ErrorDisplay);
        }
    }
}
