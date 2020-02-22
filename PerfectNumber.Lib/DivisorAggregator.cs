using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PerfectNumber.Lib
{
    internal class DivisorAggregator
    {
        public BigInteger Aggregate(IEnumerable<BigInteger> divisors, BigInteger number)
            => divisors.Aggregate(new BigInteger(1), (sum, divisor)
                => sum += divisor * divisor != number
                    ? divisor + number / divisor
                    : divisor);
    }
}
