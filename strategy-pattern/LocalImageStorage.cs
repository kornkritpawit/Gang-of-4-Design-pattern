using System;
using strategy_pattern;

namespace pattern_strategy
{
    public class LocalImageStorage
    {
        private string _compressor;
        private string _filter;

        public LocalImageStorage(string compressor, string filter)
        {
            _compressor = compressor;
            _filter = filter;
        }


        public void Store(string fileName)
        {
            
            if(_compressor == "JPEG") { //วิธีเก่า Single responsibility คลาสเดียวทำทุกอย่าง
                Console.WriteLine("Compressing JPEG format");
            } else if (_compressor == "PNG") {
                Console.WriteLine("Compressing PNG format");
            }

            if (_filter == "BW") {
                Console.WriteLine("Applying B&W filter");
            } else if (_filter == "HighContrast") {
                Console.WriteLine("Applying high contrast filter");
            } 


            Console.WriteLine($"Storing image {fileName}");
            
        }
    }
}