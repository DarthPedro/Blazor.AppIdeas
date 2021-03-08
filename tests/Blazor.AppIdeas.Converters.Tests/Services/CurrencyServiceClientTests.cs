using Blazor.AppIdeas.Converters.Models;
using Blazor.AppIdeas.Converters.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Services
{
    public class CurrencyServiceClientTests
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        [Fact]
        public async Task GetCurrencies()
        {
            // arrange
            var client = new CurrencyServiceClient(_httpClient);

            // act
            var result = await client.GetCurrencies();

            // assert
            Assert.NotEmpty(result);
            Assert.Contains<CurrencyDescriptor>(result, p => p.Id == "USD");
            Assert.Contains<CurrencyDescriptor>(result, p => p.Id == "EUR");
            var usd = result.First(p => p.Id == "USD");
            Assert.Equal("United States Dollar", usd.CurrencyName);
            Assert.Equal("$", usd.CurrencySymbol);
        }

        [Fact]
        public async Task GetConversionRate_WithValidLookup()
        {
            // arrange
            var client = new CurrencyServiceClient(_httpClient);

            // act
            var result = await client.GetConversionRate("USD", "CAD");

            // assert
            Assert.NotNull(result);
            Assert.Equal("USD", result.ConvertFrom);
            Assert.Equal("CAD", result.ConvertTo);
            Assert.True(result.Rate >= 1M);
        }

        [Fact]
        public async Task GetConversionRate_WithSameCurrency()
        {
            // arrange
            var client = new CurrencyServiceClient(_httpClient);

            // act
            var result = await client.GetConversionRate("EUR", "EUR");

            // assert
            Assert.NotNull(result);
            Assert.Equal("EUR", result.ConvertFrom);
            Assert.Equal("EUR", result.ConvertTo);
            Assert.True(result.Rate == 1M);
        }

        [Fact]
        public async Task GetConversionRate_WithInvalidCurrencies()
        {
            // arrange
            var client = new CurrencyServiceClient(
                _httpClient,
                "https://free.currconv.com/api/v7/currencies?apiKey=d4cf3228112bfb5a29f5",
                "https://free.currconv.com/api/v7/convert?compact=y");

            // act - assert
            await Assert.ThrowsAsync<HttpRequestException>(() => client.GetConversionRate("USD", "EUR"));
        }

        [Fact]
        public void Creation_WithNullHttpClient()
        {
            // arrange

            // act - assert
            Assert.Throws<ArgumentNullException>(() => new CurrencyServiceClient(null));
        }
    }
}
