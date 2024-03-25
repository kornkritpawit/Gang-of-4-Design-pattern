using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_strategy;

namespace strategy_pattern
{
    public class CloudImageStorage : ImageStorage
    {
        public CloudImageStorage(Compressor compressor, Filter filter) : base(compressor, filter)
        {
        }
        public override void Store(string fileName)
        {
            _compressor.Compress(fileName); //sibling กันกับ LocalImage ส่งข้อมูลหากันได้
            _filter.Filter(fileName);
            Console.WriteLine($"Storing image {fileName} to cloud.");
        }
    }
}