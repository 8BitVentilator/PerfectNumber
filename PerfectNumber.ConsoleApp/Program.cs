using PerfectNumber.Lib;
using System;

namespace PerfectNumber.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = 1;
            var end = 5;

            var bucketGenerator = new BucketGenerator();
            var bandwidthGenerator = new BandwidthGenerator();

            var buckets = bucketGenerator.Generate(end - start, Environment.ProcessorCount);
            var bandwidths = bandwidthGenerator.Generate(buckets, start).ToArray();
        }
    }
}
