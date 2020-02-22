using System.Collections.Generic;
using System.Numerics;

namespace PerfectNumber.Lib
{
    public sealed class BandwidthCalculator
    {
        private readonly BucketGenerator bucketGenerator = new BucketGenerator();
        private readonly BandwidthGenerator bandwidthGenerator = new BandwidthGenerator();

        public IEnumerable<Bandwidth> Calculate(BigInteger start, BigInteger end, int numberOfBuckets)
        {
            var buckets = bucketGenerator.Generate(end - start, numberOfBuckets);
            return bandwidthGenerator.Generate(buckets, start);
        }
    }
}
