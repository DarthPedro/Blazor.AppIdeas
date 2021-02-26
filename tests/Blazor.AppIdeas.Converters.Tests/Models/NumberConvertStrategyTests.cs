using Blazor.AppIdeas.Converters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.AppIdeas.Converters.Tests.Models
{
    public class NumberConvertStrategyTests
    {
        [Theory]
        [InlineData("101", NumberSystem.Binary, 5)]
        [InlineData("101", NumberSystem.Octal, 65)]
        [InlineData("101", NumberSystem.Decimal, 101)]
        [InlineData("1E", NumberSystem.Hexadecimal, 30)]
        [InlineData("CXLVI", NumberSystem.Roman, 146)]
        public void ConvertFrom_WithValidValues(string value, NumberSystem numberSystem, int expectedResult)
        {
            // arrange

            // act
            var result = NumberConversionStrategy.ConvertFrom(value, numberSystem);

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("102", NumberSystem.Binary)]
        [InlineData("108", NumberSystem.Octal)]
        [InlineData("10A", NumberSystem.Decimal)]
        [InlineData("1Ex", NumberSystem.Hexadecimal)]
        [InlineData("CXLV1", NumberSystem.Roman)]
        public void ConvertFrom_WithInvalidCharacters(string value, NumberSystem numberSystem)
        {
            // arrange

            // act - assert
            Assert.ThrowsAny<Exception>(() => NumberConversionStrategy.ConvertFrom(value, numberSystem));
        }

        [Theory]
        [InlineData(5, NumberSystem.Binary, "101")]
        [InlineData(65, NumberSystem.Octal, "101")]
        [InlineData(101, NumberSystem.Decimal, "101")]
        [InlineData(30, NumberSystem.Hexadecimal, "1e")]
        [InlineData(146, NumberSystem.Roman, "CXLVI")]
        public void ConvertTo_WithValidValues(int value, NumberSystem numberSystem, string expectedResult)
        {
            // arrange

            // act
            var result = NumberConversionStrategy.ConvertTo(value, numberSystem);

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(NumberSystem.Binary)]
        [InlineData(NumberSystem.Octal)]
        [InlineData(NumberSystem.Decimal)]
        [InlineData(NumberSystem.Hexadecimal)]
        [InlineData(NumberSystem.Roman)]
        public void GetNumberSystemErrorMessage(NumberSystem numberSystem)
        {
            // arrange

            // act
            var result = NumberConversionStrategy.GetNumberSystemErrorMessage(numberSystem);

            // assert
            Assert.Contains(numberSystem.ToString(), result);
        }
    }
}
