using PerfectNumber.Lib;
using System.Collections.Generic;
using System.Numerics;
using Xunit;

namespace PerfectNumber.Test
{
    public class BucketGeneratorTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Generate(BigInteger range, int buckets, IEnumerable<BigInteger> expected)
        {
            var generator = new BucketGenerator();
            Assert.Equal(expected, generator.Generate(range, buckets));
        }

        public static IEnumerable<object[]> TestData
            => new[]
            {
                new object []
                {
                    new BigInteger(1234),
                    4,
                    new BigInteger[] { 309, 309, 308, 308 }
                },
                new object[]
                {
                    new BigInteger(5),
                    4,
                    new BigInteger[] { 2, 1, 1, 1 }
                },
                new object[]
                {
                    new BigInteger(3),
                    4,
                    new BigInteger[] { 1, 1, 1 }
                }
            };
    }
}
