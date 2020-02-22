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
        private readonly BandwidthCalculator bandwidthCalculator = new BandwidthCalculator();
        private readonly DivisorCalculator divisorCalculator = new DivisorCalculator();
        private readonly DivisorAggregator divisorAggregator = new DivisorAggregator();

        public PerfectNumberValidator()
            : this(new PerfectNumberValidatorConfiguration())
        { }

        public PerfectNumberValidator(PerfectNumberValidatorConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool Validate(BigInteger number)
            => this.divisorAggregator.Aggregate(this.GetDivisors(number), number) == number && number != 1;

        private IEnumerable<BigInteger> GetDivisors(BigInteger number)
            => this.bandwidthCalculator
                .Calculate(2, (BigInteger)number.Sqrt(), configuration.NumberOfCores)
                .AsParallel()
                .SelectMany(bandwidth => divisorCalculator.Calculate(bandwidth, number));
    }
}
