using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_strategy;

namespace strategy_pattern
{
    public class PngCompressor : Compressor
    {
        public void Compress(string fileName)
        {
            Console.WriteLine("Compressing PNG format");
        }
    }
}