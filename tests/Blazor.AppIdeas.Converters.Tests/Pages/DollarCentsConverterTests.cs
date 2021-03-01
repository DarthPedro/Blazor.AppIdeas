using Blazor.AppIdeas.Converters.Pages;
using Blazor.AppIdeas.Converters.ViewModels;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    public class DollarCentsConverterTests
    {
        [Fact]
        public void InitialRender()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<DollarCentsConverterViewModel>(new DollarCentsConverterViewModel());

            // act
            var cut = ctx.RenderComponent<DollarCentsConverter>();

            // assert
            cut.MarkupMatches(DollarCentsConverterExpectedResults.DefaultRenderResult);
        }

        [Fact]
        public void DisplayErrorMessage()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<DollarCentsConverterViewModel>(new DollarCentsConverterViewModel());

            var cut = ctx.RenderComponent<DollarCentsConverter>();

            // act
            cut.Find("#btn-convert").Click();

            // assert
            cut.MarkupMatches(DollarCentsConverterExpectedResults.DollarValueErrorResult);
        }

        [Fact]
        public void Convert_Clicked()
        {
            // arrange
            using var ctx = new TestContext();
            var vm = new DollarCentsConverterViewModel { DollarValue = "1.49" };
            ctx.Services.AddSingleton<DollarCentsConverterViewModel>(vm);

            var cut = ctx.RenderComponent<DollarCentsConverter>();

            // act
            cut.Find("#btn-convert").Click();

            // assert
            cut.MarkupMatches(DollarCentsConverterExpectedResults.ConvertResult);
        }
    }
}
