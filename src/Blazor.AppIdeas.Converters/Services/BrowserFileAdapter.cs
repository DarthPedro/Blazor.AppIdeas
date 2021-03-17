using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.AppIdeas.Converters.Services
{
    public class BrowserFileAdapter : IBrowserFileAdapter
    {
        private const string _jsSaveAsFileMethod = "file.saveAsFile";
        private static readonly IList<string> _supportedMimeTypes = new List<string>
        {
            "application/json",
            "text/csv"
        };

        public async Task<string> ReadTextAsync(IBrowserFile browserFile)
        {
            _ = browserFile ?? throw new ArgumentNullException(nameof(browserFile));
            
            if (!_supportedMimeTypes.Contains(browserFile.ContentType))
            {
                throw new NotSupportedException(
                    $"File type ({browserFile.ContentType}) is not supported.");
            }

            using var file = browserFile.OpenReadStream();
            using var reader = new StreamReader(file, Encoding.UTF8);

            return await reader.ReadToEndAsync().ConfigureAwait(false);
        }

        public async Task SaveTextAsAsync(
            IJSRuntime jsRuntime,
            string filename,
            IBrowserFileAdapter.FileType fileType,
            string data)
        {
            _ = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException(nameof(filename));
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException(nameof(data));

            var buffer = Encoding.UTF8.GetBytes(data);
            await jsRuntime.InvokeVoidAsync(
                    _jsSaveAsFileMethod,
                    CalculateFullFileName(filename, fileType),
                    Convert.ToBase64String(buffer));
        }

        private string CalculateFullFileName(
            string filename,
            IBrowserFileAdapter.FileType fileType)
        {
            var mimeType = _supportedMimeTypes[(int)fileType];
            var extension = mimeType.Split("/").Last();
            return $"{filename}.{extension}";
        }
    }
}
