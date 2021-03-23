using Blazor.AppIdeas.Converters.Models;
using System;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Models
{
    public class TextConverterTests
    {
        private const string _arrayJson =
@"[
 { ""foo"" : 42,
  ""bar"" : 1,
  ""other"" : ""dude""
 },
 { ""foo"" : 99,
  ""bar"" : 100,
  ""other"" : ""where""
 },
 { ""foo"" : 69,
  ""bar"" : 420,
  ""other"" : ""more""
 }
]";

        private const string _arrayJsonMinified = 
@"[{""foo"":42,""bar"":1,""other"":""dude""},{""foo"":99,""bar"":100,""other"":""where""},{""foo"":69,""bar"":420,""other"":""more""}]";

        private const string _arrayJsonWithOptionals =
@"[
 { ""foo"" : 42,
  ""bar"" : 1,
  ""other"" : ""dude""
 },
 { ""foo"" : 99,
  ""bar"" : 100,
  ""other"" : ""where""
 },
 { ""foo"" : 69,
  ""bar"" : 420
 }
]";

        private const string _csvTest1 =
@"[
    { ""foo"" : ""42"" }
]
";
        private const string _csvTest2 =
@"[
    { ""foo"" : ""42"", ""bar"" : ""1"", ""other"" : ""dude"" }
]
";

        private const string _csvTest3 =
@"[
    { ""foo"" : ""42"", ""bar"" : ""{ ""prop"" : ""value"" }"" }
]
";

        private const string _csvTest4 =
@"[
    { ""foo"" : ""42"", ""bar"" : ""1"", ""other"" : ""dude"" }, 
    { ""foo"" : ""99"", ""bar"" : ""100"", ""other"" : ""where"" }, 
    { ""foo"" : ""69"", ""bar"" : ""420"", ""other"" : ""more"" }
]
";

        private const string _csvTest5 =
@"[
    { ""foo"" : ""42"", ""bar"" : ""1"", ""other"" : ""dude"" }
]
";

        [Theory]
        [InlineData("", "")]
        [InlineData(@"{ ""foo"" : 42 }", "foo\r\n42\r\n")]
        [InlineData(@"{ ""foo"" : 42, ""bar"" : 1, ""other"" : ""dude"" }", "foo, bar, other\r\n42, 1, dude\r\n")]
        [InlineData(@"[ { ""foo"" : 42 } ]", "foo\r\n42\r\n")]
        [InlineData(@"[ { ""foo"" : 42, ""bar"" : { ""prop"" : ""value"" } } ]", "foo, bar\r\n42, { \"prop\" : \"value\" }\r\n")]
        [InlineData(_arrayJson, "foo, bar, other\r\n42, 1, dude\r\n99, 100, where\r\n69, 420, more\r\n")]
        [InlineData(_arrayJsonWithOptionals, "foo, bar, other\r\n42, 1, dude\r\n99, 100, where\r\n69, 420\r\n")]
        [InlineData(_arrayJsonMinified, "foo, bar, other\r\n42, 1, dude\r\n99, 100, where\r\n69, 420, more\r\n")]
        public void JsonToCsv_WithValidText(string source, string expectedResult)
        {
            // arrange
            var converter = new TextConverter(source);

            // act
            var result = converter.JsonToCsv();

            // assert
            Assert.NotNull(result);
            Assert.Equal(source, converter.SourceText);
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData("", "")]
        [InlineData("foo\r\n42", _csvTest1)]
        [InlineData("foo, bar, other\r\n42, 1, dude\r\n", _csvTest2)]
        [InlineData("foo, bar\r\n42, { \"prop\" : \"value\" }\r\n", _csvTest3)]
        [InlineData("foo, bar, other\r\n42, 1, dude\r\n99, 100, where\r\n69, 420, more\r\n", _csvTest4)]
        [InlineData("foo, bar, other\r\n42, 1, dude, 99, 100, where, 69, 420, more\r\n", _csvTest5)]
        public void CsvToJsonTo_WithValidText(string source, string expectedResult)
        {
            // arrange
            var converter = new TextConverter(source);

            // act
            var result = converter.CsvToJson();

            // assert
            Assert.NotNull(result);
            Assert.Equal(source, converter.SourceText);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Constructor_WithNullSourceText()
        {
            // arrange

            // act - assert
            Assert.Throws<ArgumentNullException>(() => new TextConverter(null));
        }

        [Fact]
        public void JsonToCsv_WithInvalidRootType()
        {
            // arrange
            var converter = new TextConverter("42");

            // act - assert
            Assert.Throws<NotSupportedException>(() => converter.JsonToCsv());
        }

        [Fact]
        public void JsonToCsv_WithNonJsonFormat()
        {
            // arrange
            var converter = new TextConverter("foo, bar, other\r\n42, 1, dude\r\n99, 100, where\r\n69, 420, more\r\n");

            // act - assert
            Assert.ThrowsAny<Exception>(() => converter.JsonToCsv());
        }

        [Fact]
        public void CsvToJson_WithNonCsvFormat()
        {
            // arrange
            var converter = new TextConverter("foo, bar, other\r\n42, 1, dude\r\n99, 100\r\n69\r\n");

            // act - assert
            Assert.ThrowsAny<FormatException>(() => converter.CsvToJson());
        }
    }
}
