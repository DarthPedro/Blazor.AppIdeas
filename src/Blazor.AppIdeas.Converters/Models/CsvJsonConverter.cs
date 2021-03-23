using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blazor.AppIdeas.Converters.Models
{
    internal class CsvJsonConverter : ITextConvertStrategy
    {
        private static readonly char[] _csvSeparators = new char[] { ',' };
        private const string _jsonSeparator = ", ";

        public string Convert(string source)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[");

            var lines = GetCsvLines(source);
            var lineCount = lines.Count();

            var properties = ParseCsvPropertyNames(lines.First());

            for (int ctr = 1; ctr < lineCount; ctr++)
            {
                var json = ParseCsvLine(lines.ElementAt(ctr), properties);
                var suffix = (ctr != lineCount - 1) ? _jsonSeparator : string.Empty;
                builder.AppendLine(json + suffix);
            }

            builder.AppendLine("]");
            return builder.ToString();
        }

        private IEnumerable<string> GetCsvLines(string text) =>
            text.Split(System.Environment.NewLine,
                       StringSplitOptions.RemoveEmptyEntries);

        private IEnumerable<string> ParseCsvPropertyNames(string line) =>
            line.Split(_csvSeparators,
                       StringSplitOptions.RemoveEmptyEntries);

        private string ParseCsvLine(string line, IEnumerable<string> properties)
        {
            var values = line.Split(_csvSeparators,
                                    StringSplitOptions.RemoveEmptyEntries);

            if (values.Length < properties.Count())
                throw new FormatException();

            string jsonLine = string.Empty;
            for (int ctr = 0; ctr < properties.Count(); ctr++)
            {
                jsonLine += FormatJsonProperty(properties.ElementAt(ctr).Trim(),
                                               values.ElementAt(ctr).Trim());
            }

            return FormatJsonLine(jsonLine);
        }

        private string FormatJsonProperty(string property, string value) =>
            @$"""{property}"" : ""{value}"", ";

        private string FormatJsonLine(string jsonLine) =>
            "    { " + jsonLine.TrimEnd(',', ' ') + " }";
    }
}
