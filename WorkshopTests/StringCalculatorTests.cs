using TDDWorkshop;

namespace WorkshopTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void ShouldReturnZeroIfStringEmpty()
        {
            string str = "";

            int result = StringCalculator.Calculate(str);

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("0", 0)]
        [InlineData("121", 121)]
        [InlineData("42", 42)]
        public void ShouldReturnValueIfSingleNumberString(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12,2", 14)]
        [InlineData("0,0", 0)]
        [InlineData("121,0", 121)]
        [InlineData("38,42", 80)]
        public void ShouldReturnSumIfTwoCommaSeparatedValues(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n2", 14)]
        [InlineData("0\n0", 0)]
        [InlineData("121\n0", 121)]
        [InlineData("38\n42", 80)]
        public void ShouldReturnSumIfTwoNewLineSeparatedValues(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n2,4", 18)]
        [InlineData("0,0\n0", 0)]
        [InlineData("121\n0\n5", 126)]
        [InlineData("3,9,5", 17)]
        public void ShouldReturnSumIfMultipleCommaOrNewLineSeparatedValues(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("12\n2,4,10001", 18)]
        [InlineData("0,0\n0,1500", 0)]
        [InlineData("121\n0\n5,1000", 1126)]
        [InlineData("3,999,9,5", 1016)]
        [InlineData("1001", 0)]
        public void ShouldIgnoreValuesBiggerThanOneThousand(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("121\n0\n-5,1000")]
        [InlineData("3,999,9,-5")]
        [InlineData("-5")]
        public void ShouldThrowIfAnyValueNegative(string str)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.Calculate(str));
        }

        [Theory]
        [InlineData("//c\n12\n2,4c10001", 18)]
        [InlineData("//$\n0,0$0,1500", 0)]
        [InlineData("121\n0\n5,1000", 1126)]
        [InlineData("// \n3 999,9 5", 1016)]
        [InlineData("//X\n1001", 0)]
        public void ShouldCalculateSumWithCustomSeparator(string str, int expected)
        {
            int result = StringCalculator.Calculate(str);

            Assert.Equal(expected, result);
        }
    }
}