using Blazor.AppIdeas.Converters.Services;
using System;

namespace Blazor.AppIdeas.Converters.Models
{
    public class TextConverter
    {
        public TextConverter(string text)
        {
            SourceText = text ?? throw new ArgumentNullException(nameof(text));
        }

        public string SourceText { get; }

        public string JsonToCsv() =>
            PerformConversionTo(IBrowserFileAdapter.FileType.CSV);

        public string CsvToJson() =>
            PerformConversionTo(IBrowserFileAdapter.FileType.JSON);

        private string PerformConversionTo(IBrowserFileAdapter.FileType type)
        {
            if (string.IsNullOrEmpty(SourceText)) return string.Empty;

            ITextConvertStrategy converter = (type == IBrowserFileAdapter.FileType.CSV) ?
                                                new JsonCsvConverter() : 
                                                new CsvJsonConverter();
            return converter.Convert(SourceText);
        }
    }
}
