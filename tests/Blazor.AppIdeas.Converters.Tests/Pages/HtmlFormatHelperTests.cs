using Blazor.AppIdeas.Converters.Models;
using Blazor.AppIdeas.Converters.Pages;
using System;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Pages
{
    public class HtmlFormatHelperTests
    {
        [Fact]
        public void GetEnumData_NumberSystem()
        {
            // arrange

            // act
            var data = HtmlFormatHelper.GetEnumData<NumberSystem>();

            // assert
            Assert.NotNull(data);
            Assert.Contains<Tuple<string, NumberSystem>>(data, p => p.Item1 == "Decimal");
            Assert.Contains<Tuple<string, NumberSystem>>(data, p => p.Item2 == NumberSystem.Octal);
        }
    }
}
