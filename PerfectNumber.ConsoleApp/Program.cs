using PerfectNumber.Lib;
using System;
using System.Diagnostics;
using System.Linq;

namespace PerfectNumber.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new PerfectNumberValidator();
            var asd = validator.Validate(6);
        }
    }
}
