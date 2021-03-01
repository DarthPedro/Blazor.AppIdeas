using Blazor.AppIdeas.Converters.Models;
using System.Linq;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Models
{
    public class CoinCalculatorTests
    {
        [Theory]
        [InlineData(18, 0, 1, 1, 3)]
        [InlineData(137, 5, 1, 0, 2)]
        [InlineData(1, 0, 0, 0, 1)]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(400, 16, 0, 0, 0)]
        [InlineData(11, 0, 1, 0, 1)]
        [InlineData(5, 0, 0, 1, 0)]
        [InlineData(41, 1, 1, 1, 1)]
        public void CalculateCoinBreakdown_WithValidCents(
            int initialCents,
            int expectedQuarters,
            int expectedDimes,
            int expectedNickels,
            int expectedPennies)
        {
            // arrange

            // act
            var results = CoinCalculator.CalculateCoinBreakdown(initialCents);

            // assert
            Assert.Equal(4, results.Count);
            Assert.Equal(expectedQuarters, results.First(p => p.Type == CoinType.Quarter).Amount);
            Assert.Equal(expectedDimes, results.First(p => p.Type == CoinType.Dime).Amount);
            Assert.Equal(expectedNickels, results.First(p => p.Type == CoinType.Nickel).Amount);
            Assert.Equal(expectedPennies, results.First(p => p.Type == CoinType.Penny).Amount);
        }

        [Fact]
        public void CalculateCoinBreakdown_WithNegativeCents()
        {
            // arrange

            // act
            var results = CoinCalculator.CalculateCoinBreakdown(-16);

            // assert
            Assert.Empty(results);
        }
    }
}
