using System.Collections.Generic;
using System.Numerics;

namespace PerfectNumber.Lib
{
    public class PerfectNumberDivisorPartsCalculator
    {
        private readonly BigInteger start;
        private readonly BigInteger count;
        private readonly BigInteger number;

        public PerfectNumberDivisorPartsCalculator(BigInteger start, BigInteger count, BigInteger number)
        {
            this.start = start;
            this.count = count;
            this.number = number;
        }

        public IEnumerable<BigInteger> Calculate()
        {
            for (var x = this.start; x - this.start < this.count && x * x <= this.number; x++)
            {
                if(this.number % x == 0)
                    yield return x;
            }
        }
    }
}
