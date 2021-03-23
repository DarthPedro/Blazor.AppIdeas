using System;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Blazor.AppIdeas.Converters.Models
{
    internal class JsonCsvConverter : ITextConvertStrategy
    {
        private string _sourceText;

        public string Convert(string source)
        {
            _sourceText = source;
            var result = new StringBuilder();
            var element = GetJsonRootArray();

            result.AppendLine(ParseJsonPropertyNames(element));
            result.Append(ParseJsonElementArray(element));

            return result.ToString();
        }

        private JsonElement GetJsonRootArray()
        {
            var doc = JsonDocument.Parse(_sourceText);
            if (doc.RootElement.ValueKind == JsonValueKind.Object)
            {
                doc = JsonDocument.Parse($"[{_sourceText}]");
            }

            if (doc.RootElement.ValueKind != JsonValueKind.Array)
            {
                throw new NotSupportedException("Unsupported JSON root type.");
            }

            return doc.RootElement;
        }

        private string ParseJsonPropertyNames(JsonElement root)
        {
            var result = new StringBuilder();
            var firstElement = root.EnumerateArray().First();

            foreach (var property in firstElement.EnumerateObject())
            {
                result.Append($"{property.Name}, ");
            }

            return result.ToString().TrimEnd(',', ' ');
        }

        private string ParseJsonElementArray(JsonElement element)
        {
            StringBuilder result = new StringBuilder();

            foreach (var e in element.EnumerateArray())
            {
                result.AppendLine(ParseJsonElement(e));
            }

            return result.ToString();
        }

        private string ParseJsonElement(JsonElement element)
        {
            var result = new StringBuilder();
            foreach (var property in element.EnumerateObject())
            {
                result.Append($"{property.Value}, ");
            }

            return result.ToString().TrimEnd(',', ' ');
        }
    }
}
