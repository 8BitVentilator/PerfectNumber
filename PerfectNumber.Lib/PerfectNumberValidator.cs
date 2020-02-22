using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PerfectNumber.Lib
{
    /* A Simple Solution is to go through every number from 1 to n-1 and check if it is a divisor. 
     * Maintain sum of all divisors. If sum becomes equal to n, then return true, else return false.
     * 
     * An Efficient Solution is to go through numbers till square root of n. 
     * If a number ‘i’ divides n, then add both ‘i’ and n/i to sum.
     * Below is the implementation of efficient solution.
     * 
     * My Validator implements the Efficient Solution.
     */
    public sealed class PerfectNumberValidator
    {
        private readonly PerfectNumberValidatorConfiguration configuration;
        private readonly BucketGenerator bucketGenerator = new BucketGenerator();
        private readonly BandwidthGenerator bandwidthGenerator = new BandwidthGenerator();
        private readonly DivisorCalculator divisorCalculator = new DivisorCalculator();

        public PerfectNumberValidator()
            : this(new PerfectNumberValidatorConfiguration())
        { }

        public PerfectNumberValidator(PerfectNumberValidatorConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool Validate(BigInteger number)
        {
            var sqrt = (BigInteger)number.Sqrt();
            var buckets = this.bucketGenerator.Generate(sqrt - 2, configuration.NumberOfCores);
            var bandwidths = this.bandwidthGenerator.Generate(buckets, 2);
            var divisors = bandwidths.Select(bandwidth => divisorCalculator.Calculate(bandwidth, number))
                                     .AsParallel()
                                     .SelectMany(x => x);

            return Sum(divisors, number) == number && number != 1;
        }

        private static BigInteger Sum(IEnumerable<BigInteger> enumerable, BigInteger number)
        {
            BigInteger sum = 1;
            foreach (var i in enumerable)
            {
                sum += i * i != number
                        ? i + number / i
                        : i;
            }

            return sum;
        }
    }
}
