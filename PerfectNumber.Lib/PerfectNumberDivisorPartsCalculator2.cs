using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace PerfectNumber.Lib
{
    public class PerfectNumberDivisorPartsCalculator2
    {
        private readonly Bandwidth bandwidth;
        private readonly BigInteger number;

        public PerfectNumberDivisorPartsCalculator2(Bandwidth bandwidth, BigInteger number)
        {
            this.bandwidth = bandwidth;
            this.number = number;
        }

        public Task<IEnumerable<BigInteger>> Calculate()
        {
            return Task.Factory.StartNew(CalculateImpl);

        }

        private IEnumerable<BigInteger> CalculateImpl()
        {
            for (var x = bandwidth.Start; x <= bandwidth.End; x++)
            {
                if (number % x == 0)
                {
                    Console.WriteLine(x);
                    yield return x;
                }
            }
        }
    }
}

    