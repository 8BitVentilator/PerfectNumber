using System.Numerics;

namespace PerfectNumber.Lib
{
    public sealed class Bandwidth
    {
        public BigInteger Start { get; }
        public BigInteger End { get; }

        public Bandwidth(BigInteger start, BigInteger end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
