using PerfectNumber.Lib;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PerfectNumber.Test
{
    internal class BandwidthComparer : IEqualityComparer<Bandwidth>
    {
        public bool Equals([AllowNull] Bandwidth x, [AllowNull] Bandwidth y)
        {
            if (x == null || y == null)
                return false;

            return x.Start == y.Start
                    && y.End == y.End;
        }

        public int GetHashCode([DisallowNull] Bandwidth obj) => obj.GetHashCode();
    }
}
