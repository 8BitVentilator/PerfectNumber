using PerfectNumber.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace PerfectNumber.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var start = 0;
            //var end = 1000;
            //var numberOfCores = Environment.ProcessorCount;

            //var bandwidths = new BandwidthCalculator().Calculate(start, end, numberOfCores);

            var numberOfCores = Environment.ProcessorCount;
            BigInteger number = 2305843008139952128; // 496;

            BigInteger steps = Steps(number);
            var buckets = new BucketGenerator().Generate(steps - 2, numberOfCores).ToArray();
            var bandwidths = new BandwidthGenerator().Generate(buckets, 2).ToArray();

            var tasks = bandwidths
                            .Select(bandwidth => new PerfectNumberDivisorPartsCalculator2(bandwidth, number))
                            .Select(calculator => calculator.Calculate());

            //var qwe = await Task.WhenAll(tasks).ContinueWith(x => Sum(x.Result.SelectMany(x => x), number)); 
            //var qwe = (await Task.WhenAll(tasks)).AsParallel().SelectMany(x => x).ToArray(); 
            var qwe = (await Task.WhenAll(tasks)).AsParallel().SelectMany(x => x);
            var qwe2 = Sum(qwe, number);

        }

        private static BigInteger Sum(IEnumerable<BigInteger> enumerable, BigInteger number)
        {
            BigInteger sum = 1;
            foreach (var i in enumerable)
            {
                sum += i * i != number
                        ? i + number / i
                        : i;
            }

            return sum;
        }

        static BigInteger Steps(BigInteger value) => (BigInteger)Sqrt(value);

        static double Sqrt(BigInteger value) => Math.Exp(BigInteger.Log(value) / 2);
    }
}
