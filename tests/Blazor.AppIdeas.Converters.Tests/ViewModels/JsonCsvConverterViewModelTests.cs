using Blazor.AppIdeas.Converters.ViewModels;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.ViewModels
{
    public class JsonCsvConverterViewModelTests
    {
        [Fact]
        public void Construction()
        {
            // arrange

            // act
            var vm = new JsonCsvConverterViewModel();

            // assert
            Assert.NotNull(vm);
            Assert.Null(vm.SourceText);
            Assert.Null(vm.ConvertedText);
            Assert.Null(vm.ErrorMessage);
            Assert.False(vm.HasError);
        }

        [Theory]
        [InlineData(@"[ { ""foo"" : 42 } ]", "foo\r\n42\r\n", false)]
        [InlineData(@"[ { ""foo"" : 42, ""bar"" : { ""prop"" : ""value"" } } ]", "foo, bar\r\n42, { \"prop\" : \"value\" }\r\n", false)]
        [InlineData(@"[ ""foo"" : 42 } ]", null, true)]
        [InlineData("", "", false)]
        [InlineData(null, null, true)]
        public void ConvertToCsv(string source, string expectedConverted, bool expectedError)
        {
            // arrange
            var vm = new JsonCsvConverterViewModel()
            {
                SourceText = source
            };

            // act
            vm.ConvertToCsv();

            // assert
            Assert.Equal(expectedConverted, vm.ConvertedText);
            Assert.Equal(expectedError, vm.HasError);
        }

        [Fact]
        public void ClearAll()
        {
            // arrange
            var vm = new JsonCsvConverterViewModel()
            {
                SourceText = "garbage in",
                ConvertedText = "garbage out"
            };

            // act
            vm.ClearAll();

            // assert
            Assert.Empty(vm.SourceText);
            Assert.Empty(vm.ConvertedText);
            Assert.Null(vm.ErrorMessage);
            Assert.False(vm.HasError);
        }

        [Fact]
        public void Copy()
        {
            // arrange
            var vm = new JsonCsvConverterViewModel()
            {
                ConvertedText = "text to copy..."
            };

            // act
            vm.Copy();

            // assert
        }
    }
}
