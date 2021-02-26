using Blazor.AppIdeas.Converters.Models;
using Blazor.AppIdeas.Converters.Pages;
using Blazor.AppIdeas.Converters.ViewModels;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    public class NumberConverterTests
    {
        [Fact]
        public void InitialRender()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<NumberConverterViewModel>(new NumberConverterViewModel());

            // act
            var cut = ctx.RenderComponent<NumberConverter>();

            // assert
            cut.MarkupMatches(NumberConverterExpectedResults.DefaultRenderResult);
        }

        [Fact]
        public void DisplayErrorMessage()
        {
            // arrange
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<NumberConverterViewModel>(new NumberConverterViewModel());

            var cut = ctx.RenderComponent<NumberConverter>();

            // act
            cut.Find("#btn-convert").Click();

            // assert
            cut.MarkupMatches(NumberConverterExpectedResults.ErrorResult);
        }

        [Fact]
        public void Convert_Clicked()
        {
            // arrange
            using var ctx = new TestContext();
            var vm = new NumberConverterViewModel
            { 
                EntryValue = "13",
                EntryNumberSystem = NumberSystem.Octal
            };
            ctx.Services.AddSingleton<NumberConverterViewModel>(vm);

            var cut = ctx.RenderComponent<NumberConverter>();

            // act
            cut.Find("#btn-convert").Click();

            // assert
            cut.MarkupMatches(NumberConverterExpectedResults.ConvertToDecimalResult);
        }
    }
}
