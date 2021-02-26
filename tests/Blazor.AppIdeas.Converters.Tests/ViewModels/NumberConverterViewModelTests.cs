using Blazor.AppIdeas.Converters.Models;
using Blazor.AppIdeas.Converters.ViewModels;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.ViewModels
{
    public class NumberConverterViewModelTests
    {
        [Fact]
        public void Construction()
        {
            // arrange

            // act
            var converter = new NumberConverterViewModel();

            // assert
            Assert.NotNull(converter);
            Assert.Null(converter.EntryValue);
            Assert.Equal(NumberSystem.Binary, converter.EntryNumberSystem);
            Assert.Null(converter.ResultValue);
            Assert.Equal(NumberSystem.Decimal, converter.ResultNumberSystem);
            Assert.Null(converter.ErrorMessage);
            Assert.False(converter.HasError);
        }

        [Theory]
        [InlineData("101", NumberSystem.Binary, NumberSystem.Decimal, "5")]
        [InlineData("101", NumberSystem.Binary, NumberSystem.Roman, "V")]
        [InlineData("101", NumberSystem.Octal, NumberSystem.Decimal, "65")]
        [InlineData("101", NumberSystem.Octal, NumberSystem.Hexadecimal, "41")]
        [InlineData("101", NumberSystem.Decimal, NumberSystem.Decimal, "101")]
        [InlineData("101", NumberSystem.Decimal, NumberSystem.Binary, "1100101")]
        [InlineData("1E", NumberSystem.Hexadecimal, NumberSystem.Decimal, "30")]
        [InlineData("1E", NumberSystem.Hexadecimal, NumberSystem.Roman, "XXX")]
        [InlineData("CXLVI", NumberSystem.Roman, NumberSystem.Decimal, "146")]
        [InlineData("CXLVI", NumberSystem.Roman, NumberSystem.Octal, "222")]
        public void Convert_WithValidEntryValue(
            string initialEntry, 
            NumberSystem initialEntrySystem, 
            NumberSystem initialResultSystem, 
            string expectedDecimal)
        {
            // arrange
            var converter = new NumberConverterViewModel
            {
                EntryValue = initialEntry,
                EntryNumberSystem = initialEntrySystem,
                ResultNumberSystem = initialResultSystem
            };

            // act
            converter.Convert();

            // assert
            Assert.Equal(expectedDecimal, converter.ResultValue);
            Assert.Null(converter.ErrorMessage);
            Assert.False(converter.HasError);
        }

        [Theory]
        [InlineData("102", NumberSystem.Binary)]
        [InlineData("108", NumberSystem.Octal)]
        [InlineData("10A", NumberSystem.Decimal)]
        [InlineData("1Ex", NumberSystem.Hexadecimal)]
        [InlineData(null, NumberSystem.Roman)]
        public void Convert_WithValidFormatError(
            string initialEntry,
            NumberSystem initialEntrySystem)
        {
            // arrange
            var converter = new NumberConverterViewModel
            {
                EntryValue = initialEntry,
                EntryNumberSystem = initialEntrySystem,
            };

            // act
            converter.Convert();

            // assert
            Assert.Null(converter.ResultValue);
            Assert.Contains(initialEntrySystem.ToString(), converter.ErrorMessage);
            Assert.True(converter.HasError);
        }
    }
}
