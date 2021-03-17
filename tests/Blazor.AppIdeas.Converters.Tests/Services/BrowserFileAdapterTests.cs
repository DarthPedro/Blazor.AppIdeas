using Blazor.AppIdeas.Converters.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Moq;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Services
{
    public class BrowserFileAdapterTests
    {
        private const string _mimeTypeJson = "application/json";
        private static readonly IJSRuntime _jsRuntime = new Mock<IJSRuntime>().Object;

        [Fact]
        public async Task ReadTextAsync_WithValidStream()
        {
            // arrange
            var text = "Data persisted in stream.";
            var adapter = new BrowserFileAdapter();
            var stream = new MemoryStream(Encoding.ASCII.GetBytes(text));

            var mockBrowserFile = new Mock<IBrowserFile>();
            mockBrowserFile.Setup(f => f.OpenReadStream(512000, default))
                           .Returns(stream);
            mockBrowserFile.SetupGet(p => p.ContentType).Returns(_mimeTypeJson);

            // act
            var result = await adapter.ReadTextAsync(mockBrowserFile.Object)
                                      .ConfigureAwait(false);

            // assert
            Assert.Equal(text, result);
        }

        [Fact]
        public async Task ReadTextAsync_WithStreamException()
        {
            // arrange
            var adapter = new BrowserFileAdapter();

            var mockBrowserFile = new Mock<IBrowserFile>();
            mockBrowserFile.Setup(f => f.OpenReadStream(512000, default))
                           .Throws<FileLoadException>();
            mockBrowserFile.SetupGet(p => p.ContentType).Returns(_mimeTypeJson);

            // act - assert
            await Assert.ThrowsAsync<FileLoadException>(() =>
                            adapter.ReadTextAsync(mockBrowserFile.Object))
                        .ConfigureAwait(false);
        }

        [Fact]
        public async Task ReadTextAsync_WithUnsupportedContentType()
        {
            // arrange
            var adapter = new BrowserFileAdapter();

            var mockBrowserFile = new Mock<IBrowserFile>();
            mockBrowserFile.SetupGet(p => p.ContentType).Returns("application/exe");

            // act - assert
            await Assert.ThrowsAsync<NotSupportedException>(() =>
                            adapter.ReadTextAsync(mockBrowserFile.Object))
                        .ConfigureAwait(false);
        }

        [Fact]
        public async Task ReadTextAsync_WithNullFileBrowser()
        {
            // arrange
            var adapter = new BrowserFileAdapter();

            // act - assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                    adapter.ReadTextAsync(null)).ConfigureAwait(false);
        }

        [Fact]
        public async Task SaveTextAsAsync_WithValidText()
        {
            // arrange
            var adapter = new BrowserFileAdapter();

            // act
            await adapter.SaveTextAsAsync(
                _jsRuntime,
                "TestFile",
                IBrowserFileAdapter.FileType.CSV,
                "Test data to save").ConfigureAwait(false);

            // assert

        }

        [Theory]
        [InlineData(null, "TestFile", "Test data to save")]
        [InlineData("jsruntime", "", "Test data to save")]
        [InlineData("jsruntime", "TestFile", null)]
        public async Task ReadTextAsync_WithInputErrors(string jsRuntime, string filename, string data)
        {
            // arrange
            var adapter = new BrowserFileAdapter();
            var js = string.IsNullOrEmpty(jsRuntime) ? null : _jsRuntime;

            // act - assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                    adapter.SaveTextAsAsync(
                        js,
                        filename,
                        IBrowserFileAdapter.FileType.CSV,
                        data)).ConfigureAwait(false);
        }
    }
}
