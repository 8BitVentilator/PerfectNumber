using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PerfectNumber.Lib
{
    internal class BandwidthGenerator
    {
        public IEnumerable<Bandwidth> Generate(IEnumerable<BigInteger> buckets, BigInteger start) =>
            buckets
                .Select((bucket, index) => new { Bucket = bucket, Index = index })
                .Select(item => new Bandwidth(start + (item.Index == 0 ? 0 : 1), start += item.Bucket));
    }
}
