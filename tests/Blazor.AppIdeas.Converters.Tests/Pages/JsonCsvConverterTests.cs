using Blazor.AppIdeas.Converters.Pages;
using Blazor.AppIdeas.Converters.Services;
using Blazor.AppIdeas.Converters.ViewModels;
using Bunit;
using Bunit.JSInterop;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    public class JsonCsvConverterTests
    {
        private readonly IJSRuntime _jsRuntime = new Mock<IJSRuntime>().Object;
        private readonly IOptions<RemoteBrowserFileStreamOptions> _options =
            new Mock<IOptions<RemoteBrowserFileStreamOptions>>().Object;
        private readonly IBrowserFileAdapter _fileAdapter;

        public JsonCsvConverterTests()
        {
            var mockFileAdapter = new Mock<IBrowserFileAdapter>();
            mockFileAdapter.Setup(f => f.ReadTextAsync(It.IsAny<IBrowserFile>()))
                           .Returns(Task.FromResult(@"{ ""foo"" : ""test"" }"));
            _fileAdapter = mockFileAdapter.Object;
        }

        [Fact]
        public void InitialRender()
        {
            // arrange
            using var ctx = CreateConfiguredContext();
            ctx.Services.AddSingleton<JsonCsvConverterViewModel>(
                new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter));

            // act
            var cut = ctx.RenderComponent<JsonCsvConverter>();

            // assert
            cut.MarkupMatches(JsonCsvConverterExpectedResults.DefaultRenderResult);
        }

        [Fact]
        public void DisplayErrorMessage()
        {
            // arrange
            using var ctx = CreateConfiguredContext();
            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter);
            ctx.Services.AddSingleton<JsonCsvConverterViewModel>(vm);

            var cut = ctx.RenderComponent<JsonCsvConverter>();

            // act
            cut.Find("#btn-convert-csv").Click();

            // assert
            cut.MarkupMatches(JsonCsvConverterExpectedResults.ErrorResult);
        }

        [Fact]
        public void ClearAllButtonClicked()
        {
            // arrange
            using var ctx = CreateConfiguredContext();

            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter)
            {
                SourceText = "Test source text",
                ConvertedText = "Test resulting converted text"
            };
            ctx.Services.AddSingleton<JsonCsvConverterViewModel>(vm);

            var cut = ctx.RenderComponent<JsonCsvConverter>();

            // act
            cut.Find("#btn-clear").Click();

            // assert
            cut.MarkupMatches(JsonCsvConverterExpectedResults.DefaultRenderResult);
        }

        [Fact]
        public void ToCsvButtonClicked()
        {
            // arrange
            using var ctx = CreateConfiguredContext();

            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter)
            {
                SourceText = "{ \"foo\" : 42, \"bar\" : \"data\" }",
            };
            ctx.Services.AddSingleton<JsonCsvConverterViewModel>(vm);

            var cut = ctx.RenderComponent<JsonCsvConverter>();

            // act
            cut.Find("#btn-convert-csv").Click();

            // assert
            Assert.Contains("foo, bar", cut.Markup);
            Assert.Contains("42, data", cut.Markup);
        }

        [Fact]
        public void ToJsonButtonClicked()
        {
            // arrange
            using var ctx = CreateConfiguredContext();

            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter)
            {
                SourceText = "foo, bar\r\n42, data",
            };
            ctx.Services.AddSingleton<JsonCsvConverterViewModel>(vm);

            var cut = ctx.RenderComponent<JsonCsvConverter>();

            // act
            cut.Find("#btn-convert-json").Click();

            // assert
            Assert.Contains("&quot;foo&quot; : &quot;42&quot;", cut.Markup);
            Assert.Contains("&quot;bar&quot; : &quot;data&quot;", cut.Markup);
        }

        private TestContext CreateConfiguredContext()
        {
            var ctx = new TestContext();
            ctx.Services.AddSingleton<IOptions<RemoteBrowserFileStreamOptions>>(_options);
            ctx.JSInterop.SetupVoid("Blazor._internal.InputFile.init", x => true);

            return ctx;
        }
    }
}
