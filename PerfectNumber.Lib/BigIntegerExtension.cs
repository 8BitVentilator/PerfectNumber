using System;
using System.Numerics;

namespace PerfectNumber.Lib
{
    internal static class BigIntegerExtension
    {
        // TODO: Possibly find another solution. The double data type might cause problems.
        public static double Sqrt(this BigInteger value) => Math.Exp(BigInteger.Log(value) / 2);
    }
}
