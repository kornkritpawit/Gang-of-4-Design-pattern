using System;
using strategy_pattern;

namespace pattern_strategy
{
    public class LocalImageStorageStrategy1
    {
        private Compressor _compressor; //Inherit
        private Filter _filter;

        //ต่างจาก State pattern ตรงที่ state Object เดียวทำงานทุก Function
        // Strategy มีหลาย algo/Object เช่น Filter, Compressor แยกกัน 1 ตัวทำงาน 1 ชิ้น
        public LocalImageStorageStrategy1(Compressor compressor, Filter filter)
        {
            _compressor = compressor;
            _filter = filter;
        }


        public void Store(string fileName)
        {
            _compressor.Compress(fileName);
            _filter.Filter(fileName);
            Console.WriteLine($"Storing image {fileName}");
            
        }
    }
}