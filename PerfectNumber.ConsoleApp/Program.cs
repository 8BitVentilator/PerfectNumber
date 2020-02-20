using PerfectNumber.Lib;
using System;

namespace PerfectNumber.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = 0;
            var end = 1000;
            var numberOfCores = Environment.ProcessorCount;

            var bandwidths = new BandwidthCalculator().Calculate(start, end, numberOfCores);
        }
    }
}
