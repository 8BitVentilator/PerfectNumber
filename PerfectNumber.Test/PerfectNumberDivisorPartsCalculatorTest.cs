using PerfectNumber.Lib;
using System.Linq;
using Xunit;

namespace PerfectNumber.Test
{
    public class PerfectNumberDivisorPartsCalculatorTest
    {
        [Fact]
        public void Test1()
        {
            var calculator = new PerfectNumberDivisorPartsCalculator(2, 1000, 496);
            var result = calculator.Calculate().ToArray();
        }
    }
}
