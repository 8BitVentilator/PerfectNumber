using PerfectNumber.Lib;
using System;
using System.Diagnostics;

namespace PerfectNumber.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var number = 6;
            var number = 2305843008139952128;
            var validator = new PerfectNumberValidator();
            var sw = new Stopwatch();
            sw.Start();
            var isPerfect = validator.Validate(number);
            sw.Stop();

            Console.WriteLine($"{number} ist{(isPerfect ? " " : " nicht ")}perfekt.");
            Console.WriteLine($"Zeit: {sw.Elapsed}");
        }
    }
}
