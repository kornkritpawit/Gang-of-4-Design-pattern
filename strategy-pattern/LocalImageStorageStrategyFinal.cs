using System;
using strategy_pattern;

namespace pattern_strategy
{
    public class LocalImageStorageStrategyFinal : ImageStorage
    {

        public LocalImageStorageStrategyFinal(Compressor compressor, Filter filter) : base(compressor, filter) 
        {
        }


        public override void Store(string fileName)
        {
            // แชร์โค้กกันระหว่าง Local กับ Cloud
            _compressor.Compress(fileName);
            _filter.Filter(fileName);

            Console.WriteLine($"Storing image {fileName}");
            
        }
    }
}