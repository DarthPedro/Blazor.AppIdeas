using Blazor.AppIdeas.Converters.Services;
using Blazor.AppIdeas.Converters.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.ViewModels
{
    public class JsonCsvConverterViewModelTests
    {
        private readonly IJSRuntime _jsRuntime = new Mock<IJSRuntime>().Object;
        private readonly IBrowserFileAdapter _fileAdapter;
        private readonly IBrowserFile _testFile = new Mock<IBrowserFile>().Object;

        public JsonCsvConverterViewModelTests()
        {
            var mockFileAdapter = new Mock<IBrowserFileAdapter>();
            mockFileAdapter.Setup(f => f.ReadTextAsync(It.IsAny<IBrowserFile>()))
                           .Returns(Task.FromResult("File data..."));
            _fileAdapter = mockFileAdapter.Object;
        }

        [Fact]
        public void Construction()
        {
            // arrange

            // act
            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter);

            // assert
            Assert.NotNull(vm);
            Assert.Null(vm.SourceText);
            Assert.Null(vm.ConvertedText);
            Assert.True(vm.IsConvertedTextEmpty);
            Assert.Null(vm.ErrorMessage);
            Assert.False(vm.HasError);
        }

        [Fact]
        public void Construction_WithNullIJSRuntime()
        {
            // arrange

            // act - assert
            Assert.Throws<ArgumentNullException>(() => new JsonCsvConverterViewModel(null, _fileAdapter));
        }

        [Fact]
        public void Construction_WithNullIBrowserFileAdapter()
        {
            // arrange

            // act - assert
            Assert.Throws<ArgumentNullException>(() => new JsonCsvConverterViewModel(_jsRuntime, null));
        }

        [Theory]
        [InlineData(@"[ { ""foo"" : 42 } ]", "foo\r\n42\r\n", false, false)]
        [InlineData(@"[ { ""foo"" : 42, ""bar"" : { ""prop"" : ""value"" } } ]", "foo, bar\r\n42, { \"prop\" : \"value\" }\r\n", false, false)]
        [InlineData(@"[ ""foo"" : 42 } ]", null, true, true)]
        [InlineData("", "", true, false)]
        [InlineData(null, null, true, true)]
        public void ConvertToCsv(string source, string expectedConverted, bool expectedConvertedEmpty, bool expectedError)
        {
            // arrange
            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter)
            {
                SourceText = source
            };

            // act
            vm.ConvertToCsv();

            // assert
            Assert.Equal(expectedConverted, vm.ConvertedText);
            Assert.Equal(expectedConvertedEmpty, vm.IsConvertedTextEmpty);
            Assert.Equal(expectedError, vm.HasError);
        }

        [Fact]
        public void ClearAll()
        {
            // arrange
            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter)
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
        public async Task Copy()
        {
            // arrange
            var mockRuntime = new Mock<IJSRuntime>();
            var vm = new JsonCsvConverterViewModel(mockRuntime.Object, _fileAdapter)
            {
                ConvertedText = "text to copy..."
            };

            // act
            await vm.Copy().ConfigureAwait(false);

            // assert
            mockRuntime.Verify(f => f.InvokeAsync<object>(
                                "clipboardCopy.copyText",
                                new object[] { "text to copy..." }));
        }

        [Fact]
        public async Task OpenInputFile_WithValidChangeEventArgs()
        {
            // arrange
            var files = new List<IBrowserFile> { _testFile };
            var args = new InputFileChangeEventArgs(files);
            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter);

            // act
            await vm.OpenInputFile(args).ConfigureAwait(false);

            // assert
            Assert.NotEmpty(vm.SourceText);
            Assert.Equal("File data...", vm.SourceText);
            Assert.False(vm.HasError);
        }

        [Fact]
        public async Task OpenInputFile_WithNullValidChangeEventArgs()
        {
            // arrange
            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter);

            // act
            await vm.OpenInputFile(null).ConfigureAwait(false);

            // assert
            Assert.Null(vm.SourceText);
            Assert.True(vm.HasError);
        }

        [Fact]
        public async Task OpenInputFile_WithChangeEventArgsWithMultipleFiles()
        {
            // arrange
            var files = new List<IBrowserFile> { _testFile, _testFile, _testFile };
            var args = new InputFileChangeEventArgs(files);
            var vm = new JsonCsvConverterViewModel(_jsRuntime, _fileAdapter);

            // act
            await vm.OpenInputFile(args).ConfigureAwait(false);

            // assert
            Assert.Null(vm.SourceText);
            Assert.True(vm.HasError);
        }

        [Fact]
        public async Task OpenInputFile_WithAdapterException()
        {
            // arrange
            var files = new List<IBrowserFile> { _testFile };
            var args = new InputFileChangeEventArgs(files);

            var errorAdapter = new Mock<IBrowserFileAdapter>(MockBehavior.Strict).Object;
            var vm = new JsonCsvConverterViewModel(_jsRuntime, errorAdapter);

            // act
            await vm.OpenInputFile(args).ConfigureAwait(false);

            // assert
            Assert.Null(vm.SourceText);
            Assert.True(vm.HasError);
        }
    }
}
