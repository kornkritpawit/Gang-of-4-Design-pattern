using System;
using strategy_pattern;

namespace pattern_strategy
{
    public class LocalImageStorage : ImageStorage
    {
        // private string _compressor;
        // private string _filter;

        // private Compressor _compressor; //Inherit
        // private Filter _filter;
        public LocalImageStorage(Compressor compressor, Filter filter) : base(compressor, filter) 
        {
            // _compressor = compressor;
            // _filter = filter;
        }


        public override void Store(string fileName)
        {
            
            // if(_compressor == "JPEG") { //วิธีเก่า Single responsibility คลาสเดียวทำทุกอย่าง
            //     Console.WriteLine("Compressing JPEG format");
            // } else if (_compressor == "PNG") {
            //     Console.WriteLine("Compressing PNG format");
            // }

            // if (_filter == "BW") {
            //     Console.WriteLine("Applying B&W filter");
            // } else if (_filter == "HighContrast") {
            //     Console.WriteLine("Applying high contrast filter");
            // }
            _compressor.Compress(fileName);
            _filter.Filter(fileName);

            Console.WriteLine($"Storing image {fileName}");
            
        }
    }
}