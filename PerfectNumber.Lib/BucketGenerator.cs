using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PerfectNumber.Lib
{
    public sealed class BucketGenerator
    {
        public IEnumerable<BigInteger> Generate(BigInteger range, int countOfBuckets) =>
            Enumerable
                .Range(0, countOfBuckets)
                .Select(bucket => range / countOfBuckets + (bucket < range % countOfBuckets ? 1 : 0))
                .Where(x => x > 0);
    }
}
