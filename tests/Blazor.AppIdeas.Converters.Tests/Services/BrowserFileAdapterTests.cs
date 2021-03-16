using Blazor.AppIdeas.Converters.Services;
using Microsoft.AspNetCore.Components.Forms;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Services
{
    public class BrowserFileAdapterTests
    {
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

            // act - assert
            await Assert.ThrowsAsync<FileLoadException>(() =>
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
    }
}
