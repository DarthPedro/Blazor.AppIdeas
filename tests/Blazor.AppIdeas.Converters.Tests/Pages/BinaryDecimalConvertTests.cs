using Blazor.AppIdeas.Converters.Pages;
using Bunit;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    public class BinaryDecimalConvertTests
    {
        [Fact]
        public void InitialRender()
        {
            // arrange
            using var ctx = new TestContext();

            // act
            var cut = ctx.RenderComponent<BinaryDecimalConvert>();

            // assert
            cut.MarkupMatches(BinaryDecimalConvertExpectedResults.DefaultRenderResult);
            Assert.NotNull(cut.Instance.vm);
        }

        [Fact]
        public void DisplayErrorMessage()
        {
            // arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<BinaryDecimalConvert>();

            // act
            cut.Find("#btn-convert-decimal").Click();

            // assert
            cut.MarkupMatches(BinaryDecimalConvertExpectedResults.BinaryErrorResult);
        }

        [Fact]
        public void ConvertToDecimal_Clicked()
        {
            // arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<BinaryDecimalConvert>();
            cut.Instance.vm.Binary = "101";

            // act
            cut.Find("#btn-convert-decimal").Click();

            // assert
            cut.MarkupMatches(BinaryDecimalConvertExpectedResults.ConvertToDecimalResult);
        }

        [Fact]
        public void ConvertToBinary_Clicked()
        {
            // arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<BinaryDecimalConvert>();
            cut.Instance.vm.Decimal = "7";

            // act
            cut.Find("#btn-convert-binary").Click();

            // assert
            cut.MarkupMatches(BinaryDecimalConvertExpectedResults.ConvertToBinaryResult);
        }
    }
}
