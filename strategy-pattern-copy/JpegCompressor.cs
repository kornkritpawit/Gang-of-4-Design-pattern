using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_strategy;

namespace strategy_pattern
{
    public class JpegCompressor : Compressor
    {
        public void Compress(string fileName)
        {
            Console.WriteLine("Compressing JPEG format");
        }
    }
}