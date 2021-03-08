using Blazor.AppIdeas.Converters.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Models
{
    [ExcludeFromCodeCoverage]
    public class CurrencyConversionRateTests
    {
        [Fact]
        public void Creation()
        {
            // arrange

            // act
            var rate = new CurrencyConversion("USD", "EUR", 0.85M);

            // assert
            Assert.NotNull(rate);
            Assert.Equal("USD", rate.ConvertFrom);
            Assert.Equal("EUR", rate.ConvertTo);
            Assert.Equal(0.85M, rate.Rate);
        }

        [Fact]
        public void Creation_WithNullConvertFrom()
        {
            // arrange

            // act - assert
            Assert.Throws<ArgumentNullException>(() => new CurrencyConversion(null, "EUR", 0.85M));
        }

        [Fact]
        public void Creation_WithEmptyConvertTo()
        {
            // arrange

            // act - assert
            Assert.Throws<ArgumentNullException>(() => new CurrencyConversion("USD", "", 0.85M));
        }

        [Fact]
        public void Creation_WithNegativeValue()
        {
            // arrange

            // act - assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CurrencyConversion("USD", "EUR", -2));
        }
    }
}
