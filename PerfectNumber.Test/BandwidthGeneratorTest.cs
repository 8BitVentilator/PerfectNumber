using PerfectNumber.Lib;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

namespace PerfectNumber.Test
{
    public class BandwidthGeneratorTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        internal void Generate(IEnumerable<BigInteger> buckets, BigInteger start, IEnumerable<Bandwidth> expected)
        {
            var generator = new BandwidthGenerator();
            Assert.Equal(expected, generator.Generate(buckets, start), new BandwidthComparer());
        }

        public static IEnumerable<object[]> TestData
            => new[]
            {
                new object []
                {
                    new BigInteger[] { 309, 309, 308, 308 },
                    new BigInteger(10),
                    new Bandwidth[]
                    {
                        new Bandwidth(10,319),
                        new Bandwidth(320,628),
                        new Bandwidth(629,936),
                        new Bandwidth(937,1244),
                    }
                },
                new object[]
                {
                    new BigInteger[] { 2, 1, 1, 1 },
                    new BigInteger(10),
                    new Bandwidth[]
                    {
                        new Bandwidth(10,12),
                        new Bandwidth(13,13),
                        new Bandwidth(14,14),
                        new Bandwidth(15,15),
                    }
                }
            };
    }
}
