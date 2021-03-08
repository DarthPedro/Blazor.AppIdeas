using Blazor.AppIdeas.Converters.Models;
using Blazor.AppIdeas.Converters.Services;
using Blazor.AppIdeas.Converters.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.ViewModels
{
    public class CurrencyConverterViewModelTests
    {
        private static readonly IEnumerable<CurrencyDescriptor> _testCurrencies = new List<CurrencyDescriptor>
        {
            new CurrencyDescriptor { Id = "USD", CurrencyName = "United States Dollar", CurrencySymbol = "$" },
            new CurrencyDescriptor { Id = "YEN", CurrencyName = "Japanese Yen", CurrencySymbol = "Y" },
            new CurrencyDescriptor { Id = "EUR", CurrencyName = "Euro", CurrencySymbol = "E" },
            new CurrencyDescriptor { Id = "PES", CurrencyName = "Mexican Peso" },
            new CurrencyDescriptor { Id = "CAD", CurrencyName = "Canadian Dollar", CurrencySymbol = "$" },
        };

        private readonly ICurrencyServiceClient _testClient;
        private readonly ICurrencyServiceClient _emptyClient =
            new Mock<ICurrencyServiceClient>().Object;
        private readonly ICurrencyServiceClient _errorClient =
            new Mock<ICurrencyServiceClient>(MockBehavior.Strict).Object;

        public CurrencyConverterViewModelTests()
        {
            var mockClient = new Mock<ICurrencyServiceClient>();
            mockClient.Setup(f => f.GetCurrencies()).Returns(Task.FromResult(_testCurrencies));
            mockClient.Setup(f => f.GetConversionRate("USD", "EUR"))
                                   .Returns(Task.FromResult(
                                        new CurrencyConversion("USD", "EUR", 0.81357M)));
            mockClient.Setup(f => f.GetConversionRate("USD", "CAD"))
                                   .Returns(Task.FromResult(
                                        new CurrencyConversion("USD", "CAD", 1.2854M)));
            _testClient = mockClient.Object;
        }

        [Fact]
        public void Construction()
        {
            // arrange

            // act
            var vm = new CurrencyConverterViewModel(_emptyClient);

            // assert
            Assert.NotNull(vm);
            Assert.Equal(0M, vm.ConvertFromValue);
            Assert.Null(vm.ConvertFromCurrencyId);
            Assert.Empty(vm.ConvertFromCurrencySymbol);
            Assert.Equal(0.0M, vm.ConvertToValue);
            Assert.Null(vm.ConvertToCurrencyId);
            Assert.Empty(vm.ConvertToCurrencySymbol);
            Assert.Empty(vm.Currencies);
            Assert.Null(vm.ConversionRate);
            Assert.Null(vm.ErrorMessage);
            Assert.False(vm.HasError);
        }

        [Fact]
        public void Construction_WithNullClient()
        {
            // arrange

            // act - assert
            Assert.Throws<ArgumentNullException>(() => _ = new CurrencyConverterViewModel(null));
        }

        [Fact]
        public async Task Initialize()
        {
            // arrange
            var vm = new CurrencyConverterViewModel(_testClient);

            // act
            await vm.Initialize().ConfigureAwait(false);

            // assert
            Assert.NotNull(vm);
            Assert.Equal(0, vm.ConvertFromValue);
            Assert.Equal("USD", vm.ConvertFromCurrencyId);
            Assert.Equal("$", vm.ConvertFromCurrencySymbol);
            Assert.Equal(0.0M, vm.ConvertToValue);
            Assert.Equal("EUR", vm.ConvertToCurrencyId);
            Assert.Equal("E", vm.ConvertToCurrencySymbol);
            Assert.Equal(5, vm.Currencies.Count());
            Assert.Null(vm.ConversionRate);
            Assert.Null(vm.ErrorMessage);
            Assert.False(vm.HasError);
        }

        [Fact]
        public async Task Initialize_WithServiceError()
        {
            // arrange
            var vm = new CurrencyConverterViewModel(_errorClient);

            // act
            await vm.Initialize().ConfigureAwait(false);

            // assert
            Assert.NotNull(vm);
            Assert.Equal(0, vm.ConvertFromValue);
            Assert.Null(vm.ConvertFromCurrencyId);
            Assert.Empty(vm.ConvertFromCurrencySymbol);
            Assert.Equal(0.0M, vm.ConvertToValue);
            Assert.Null(vm.ConvertToCurrencyId);
            Assert.Empty(vm.ConvertToCurrencySymbol);
            Assert.Empty(vm.Currencies);
            Assert.Null(vm.ConversionRate);
            Assert.NotEmpty(vm.ErrorMessage);
            Assert.True(vm.HasError);
        }

        [Theory]
        [InlineData(100, "USD", "EUR", 81.36, 0.81357)]
        [InlineData(125.38326, "USD", "EUR", 102.01, 0.81357)]
        [InlineData(50.25, "USD", "CAD", 64.59, 1.2854)]
        public async Task Convert_ValidCurrencies(
            decimal amount, string convertFrom, string convertTo, decimal expectedValue, decimal expectedRate)
        {
            // arrange
            var vm = new CurrencyConverterViewModel(_testClient)
            {
                ConvertFromValue = amount,
                ConvertFromCurrencyId = convertFrom,
                ConvertToCurrencyId = convertTo
            };

            // act
            await vm.Convert().ConfigureAwait(false);

            // assert
            Assert.Equal(expectedValue, vm.ConvertToValue);
            Assert.Equal(expectedRate, vm.ConversionRate);
            Assert.False(vm.HasError);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-15.29)]
        public async Task Convert_WithError(decimal amount)
        {
            // arrange
            var vm = new CurrencyConverterViewModel(_errorClient)
            {
                ConvertFromValue = amount,
                ConvertFromCurrencyId = "YEN",
                ConvertToCurrencyId = "USD"
            };

            // act
            await vm.Convert().ConfigureAwait(false);

            // assert
            Assert.Equal(0.0M, vm.ConvertToValue);
            Assert.NotEmpty(vm.ErrorMessage);
            Assert.True(vm.HasError);
        }

        [Fact]
        public async Task SwapCurrencies()
        {
            // arrange
            var vm = new CurrencyConverterViewModel(_testClient)
            {
                ConvertFromValue = 100,
                ConvertFromCurrencyId = "EUR",
                ConvertToCurrencyId = "USD"
            };

            // act
            await vm.SwapCurrencies().ConfigureAwait(false);

            // assert
            Assert.Equal(81.36M, vm.ConvertToValue);
            Assert.Equal(0.81357M, vm.ConversionRate);
            Assert.False(vm.HasError);
        }

        [Fact]
        public async Task FindCurrencySymbol_WithNullSymbol()
        {
            // arrange
            var vm = new CurrencyConverterViewModel(_testClient);
            await vm.Initialize().ConfigureAwait(false);
            vm.ConvertToCurrencyId = "PES";

            // act
            var result = vm.ConvertToCurrencySymbol;

            // assert
            Assert.Empty(result);
        }
    }
}
