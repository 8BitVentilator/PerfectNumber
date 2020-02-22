using System;

namespace PerfectNumber.Lib
{
    public class PerfectNumberValidatorConfiguration
    {
        public int NumberOfCores { get; set; } = Environment.ProcessorCount;
    }
}
