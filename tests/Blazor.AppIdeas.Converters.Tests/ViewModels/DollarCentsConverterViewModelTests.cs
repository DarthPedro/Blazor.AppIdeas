using Blazor.AppIdeas.Converters.ViewModels;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.ViewModels
{
    public class DollarCentsConverterViewModelTests
    {
        private const string dollarErrorMessage = "The dollar value must be a valid number between 0.00 and 1000.00.";

        [Fact]
        public void Construction()
        {
            // arrange

            // act
            var converter = new DollarCentsConverterViewModel();

            // assert
            Assert.NotNull(converter);
            Assert.Null(converter.DollarValue);
            Assert.Equal(0, converter.Cents);
            Assert.Empty(converter.CoinResults);
            Assert.False(converter.HasResults);
            Assert.Null(converter.ErrorMessage);
            Assert.False(converter.HasError);
        }

        [Theory]
        [InlineData("0.41", 41, true, null, false)]
        [InlineData("1.49", 149, true, null, false)]
        [InlineData("", 0, false, dollarErrorMessage, true)]
        [InlineData("1.e4", 0, false, dollarErrorMessage, true)]
        [InlineData("-3.89", 0, false, dollarErrorMessage, true)]
        public void Convert_WithDollarValue(
            string initialDollar,
            int expectedCents,
            bool expectedResults,
            string expectedErrorMessage,
            bool expectedHasError)
        {
            // arrange
            var converter = new DollarCentsConverterViewModel
            {
                DollarValue = initialDollar
            };

            // act
            converter.Convert();

            // assert
            Assert.Equal(expectedCents, converter.Cents);
            Assert.Equal(expectedResults, converter.HasResults);
            Assert.Equal(expectedErrorMessage, converter.ErrorMessage);
            Assert.Equal(expectedHasError, converter.HasError);
        }
    }
}
