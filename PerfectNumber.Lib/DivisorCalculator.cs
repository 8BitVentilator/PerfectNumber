using System.Collections.Generic;
using System.Numerics;

namespace PerfectNumber.Lib
{
    internal class DivisorCalculator
    {
        public IEnumerable<BigInteger> Calculate(Bandwidth bandwidth, BigInteger number)
        {
            for (var x = bandwidth.Start; x <= bandwidth.End; x++)
                if (number % x == 0)
                {
                    yield return x;
                }
        }
    }
}