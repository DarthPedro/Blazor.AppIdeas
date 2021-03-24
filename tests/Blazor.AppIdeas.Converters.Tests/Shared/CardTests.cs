using Blazor.AppIdeas.Converters.Shared;
using Bunit;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Shared
{
    public class CardTests
    {
        [Fact]
        public void InitialRender()
        {
            // arrange
            using var ctx = new TestContext();

            // act
            var cut = ctx.RenderComponent<Card>();

            // assert
            var expectedMarkup =
@"  <div class=""card m-2 app-card-size"">
      <div class=""text-center mt-2"">
        <span class=""oi oi-card-image "" aria-hidden=""true""></span>
      </div>
      <div class=""card-body"">
        <p class=""card-text""></p>
      </div>
    </div>
";
            cut.MarkupMatches(expectedMarkup);
        }

        [Fact]
        public void InitialRender_WithParameters()
        {
            // arrange
            using var ctx = new TestContext();

            // act
            var cut = ctx.RenderComponent<Card>(parameters => parameters
                .Add(p => p.Title, "My Title")
                .Add(p => p.ImageCssName, "oi-home")
                .Add(p => p.ChildContent, "My card description.")
                .Add(p => p.NavigationLink, "/home"));

            // assert
            var expectedMarkup =
@"  <div class=""card m-2 app-card-size"">
      <div class=""text-center mt-2"">
        <span class=""oi oi-card-image oi-home"" aria-hidden=""true""></span>
      </div>
      <div class=""card-body"">
        <h4 class=""card-title"">My Title</h4>
        <p class=""card-text"">My card description.</p>
        <a href=""/home"" class=""stretched-link""></a>
      </div>
    </div>
";
            cut.MarkupMatches(expectedMarkup);
        }
    }
}
