using Blazor.AppIdeas.Converters.Models;
using Blazor.AppIdeas.Converters.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.AppIdeas.Converters.ViewModels
{
    public class JsonCsvConverterViewModel
    {
        private const string _jsCopyTextMethod = "clipboardCopy.copyText";
        private const string _convertedTextFilename = "ConvertedText";
        private readonly IJSRuntime _jsRuntime;
        private readonly IBrowserFileAdapter _browserFileAdapter;

        public JsonCsvConverterViewModel(
            IJSRuntime jsRuntime, IBrowserFileAdapter fileAdapter)
        {
            _jsRuntime = jsRuntime ?? 
                throw new ArgumentNullException(nameof(jsRuntime));

            _browserFileAdapter = fileAdapter ?? 
                throw new ArgumentNullException(nameof(fileAdapter));
        }

        public string SourceText { get; set; }

        public string ConvertedText { get; set; }

        public bool IsConvertedTextEmpty => string.IsNullOrEmpty(ConvertedText);

        public string ErrorMessage { get; private set; }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public void ConvertToCsv()
        {
            try
            {
                ErrorMessage = null;

                var converter = new TextConverter(SourceText);
                ConvertedText = converter.JsonToCsv();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Cannot parse source text. {ex.Message}";
                ConvertedText = null;
            }
        }

        public void ClearAll()
        {
            SourceText = null;
            ConvertedText = null;
            ErrorMessage = null;
        }

        public async Task Copy() => await _jsRuntime.InvokeVoidAsync(
                                        _jsCopyTextMethod,
                                        ConvertedText);

        public async Task OpenInputFile(InputFileChangeEventArgs e)
        {
            try
            {
                ErrorMessage = null;

                _ = e ?? throw new ArgumentNullException(nameof(e));
                if (e.FileCount > 1)
                {
                    ErrorMessage = "Application does not support multiple file selection.";
                }
                else
                {
                    SourceText = await _browserFileAdapter.ReadTextAsync(e.File)
                                                          .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Cannot read file '{e?.File.Name}'. {ex.Message}";
            }
        }

        public async Task DownloadConvertedText()
        {
            try
            {
                ErrorMessage = null;

                await _browserFileAdapter.SaveTextAsAsync(
                                            _jsRuntime,
                                            _convertedTextFilename,
                                            IBrowserFileAdapter.FileType.CSV,
                                            ConvertedText)
                                         .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Cannot download converted text file. {ex.Message}";
            }
        }
    }
}
