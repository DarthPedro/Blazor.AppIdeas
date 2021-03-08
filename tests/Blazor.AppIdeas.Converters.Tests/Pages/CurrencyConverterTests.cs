using Blazor.AppIdeas.Converters.Models;
using Blazor.AppIdeas.Converters.Pages;
using Blazor.AppIdeas.Converters.Services;
using Blazor.AppIdeas.Converters.ViewModels;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    public class CurrencyConverterTests
    {
        private static readonly IEnumerable<CurrencyDescriptor> _testCurrencies = new List<CurrencyDescriptor>
        {
            new CurrencyDescriptor { Id = "USD", CurrencyName = "United States Dollar", CurrencySymbol = "$" },
            new CurrencyDescriptor { Id = "YEN", CurrencyName = "Japanese Yen", CurrencySymbol = "Y" },
            new CurrencyDescriptor { Id = "EUR", CurrencyName = "Euro", CurrencySymbol = "E" },
            new CurrencyDescriptor { Id = "PES", CurrencyName = "Mexican Peso", CurrencySymbol = "P" },
            new CurrencyDescriptor { Id = "CAD", CurrencyName = "Canadian Dollar", CurrencySymbol = "$" },
        };

        private readonly ICurrencyServiceClient _testClient;

        public CurrencyConverterTests()
        {
            var mockClient = new Mock<ICurrencyServiceClient>();
            mockClient.Setup(f => f.GetCurrencies())
                                   .Returns(Task.FromResult(_testCurrencies));
            mockClient.Setup(f => f.GetConversionRate("USD", "EUR"))
                                   .Returns(Task.FromResult(
                                        new CurrencyConversion("USD", "EUR", 0.81357M)));
            mockClient.Setup(f => f.GetConversionRate("USD", "CAD"))
                                   .Returns(Task.FromResult(
                                        new CurrencyConversion("USD", "CAD", 1.2854M)));
            mockClient.Setup(f => f.GetConversionRate("USD", "PES"))
                                   .Throws<FormatException>();
            _testClient = mockClient.Object;
        }

        [Fact]
        public void InitialRender()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<CurrencyConverterViewModel>(
                new CurrencyConverterViewModel(_testClient));

            // act
            var cut = ctx.RenderComponent<CurrencyConverter>();

            // assert
            cut.MarkupMatches(CurrencyConverterExpectedResults.DefaultRenderResult);
        }

        [Fact]
        public void DisplayErrorMessage()
        {
            // arrange
            using var ctx = new TestContext();

            var vm = new CurrencyConverterViewModel(_testClient);
            ctx.Services.AddSingleton<CurrencyConverterViewModel>(vm);

            var cut = ctx.RenderComponent<CurrencyConverter>();
            vm.ConvertToCurrencyId = "PES";

            // act
            cut.Find("#btn-convert").Click();

            // assert
            cut.MarkupMatches(CurrencyConverterExpectedResults.ErrorResult);
        }

        [Fact]
        public void Convert_Clicked()
        {
            // arrange
            using var ctx = new TestContext();
            var vm = new CurrencyConverterViewModel(_testClient)
            {
                ConvertFromValue = 100
            };
            ctx.Services.AddSingleton<CurrencyConverterViewModel>(vm);

            var cut = ctx.RenderComponent<CurrencyConverter>();

            // act
            cut.Find("#btn-convert").Click();

            // assert
            cut.MarkupMatches(CurrencyConverterExpectedResults.ConvertCurrencyResult);
        }

        [Fact]
        public void SwapCurrencies_Clicked()
        {
            // arrange
            using var ctx = new TestContext();
            var vm = new CurrencyConverterViewModel(_testClient)
            {
                ConvertFromValue = 100
            };
            ctx.Services.AddSingleton<CurrencyConverterViewModel>(vm);

            var cut = ctx.RenderComponent<CurrencyConverter>();
            vm.ConvertFromCurrencyId = "EUR";
            vm.ConvertToCurrencyId = "USD";

            // act
            cut.Find("#btn-swap").Click();

            // assert
            cut.MarkupMatches(CurrencyConverterExpectedResults.SwapCurrenciesResult);
        }
    }
}
