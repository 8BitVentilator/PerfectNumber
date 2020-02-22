using PerfectNumber.Lib;
using System;

namespace PerfectNumber.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new PerfectNumberValidator();
            Console.WriteLine(validator.Validate(2305843008139952128));
        }
    }
}
