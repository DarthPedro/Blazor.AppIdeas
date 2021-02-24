using Blazor.AppIdeas.Converters.Pages;
using Blazor.AppIdeas.Converters.ViewModels;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    public class RomanDecimalConvertTests
    {
        [Fact]
        public void InitialRender()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<RomanDecimalConverter>(new RomanDecimalConverter());

            // act
            var cut = ctx.RenderComponent<RomanDecimalConvert>();

            // assert
            cut.MarkupMatches(RomanDecimalConvertExpectedResults.DefaultRenderResult);
        }

        [Fact]
        public void DisplayErrorMessage()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<RomanDecimalConverter>(new RomanDecimalConverter());

            var cut = ctx.RenderComponent<RomanDecimalConvert>();

            // act
            cut.Find("#btn-convert-decimal").Click();

            // assert
            cut.MarkupMatches(RomanDecimalConvertExpectedResults.RomanErrorResult);
        }

        [Fact]
        public void ConvertToDecimal_Clicked()
        {
            // arrange
            using var ctx = new TestContext();
            var vm = new RomanDecimalConverter { RomanText = "CI" };
            ctx.Services.AddSingleton<RomanDecimalConverter>(vm);

            var cut = ctx.RenderComponent<RomanDecimalConvert>();

            // act
            cut.Find("#btn-convert-decimal").Click();

            // assert
            cut.MarkupMatches(RomanDecimalConvertExpectedResults.ConvertToDecimalResult);
        }

        [Fact]
        public void ConvertToRoman_Clicked()
        {
            // arrange
            using var ctx = new TestContext();
            var vm = new RomanDecimalConverter { Decimal = "7" };
            ctx.Services.AddSingleton<RomanDecimalConverter>(vm);

            var cut = ctx.RenderComponent<RomanDecimalConvert>();

            // act
            cut.Find("#btn-convert-roman").Click();

            // assert
            cut.MarkupMatches(RomanDecimalConvertExpectedResults.ConvertToRomanResult);
        }
    }
}
