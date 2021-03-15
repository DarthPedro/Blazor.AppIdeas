using Blazor.AppIdeas.Converters.Models;
using System;

namespace Blazor.AppIdeas.Converters.ViewModels
{
    public class JsonCsvConverterViewModel
    {
        public string SourceText { get; set; }

        public string ConvertedText { get; set; }

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
            SourceText = string.Empty;
            ConvertedText = string.Empty;
            ErrorMessage = null;
        }

        public void Copy()
        {
            
        }
    }
}
