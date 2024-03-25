using System;
using strategy_pattern;

namespace pattern_strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            // var imgStorage = new LocalImageStorage("JPEG", "BW");
            // var imgStorage = new LocalImageStorageStrategy1(new JpegCompressor(), new BlackWhiteFilter());            
            ImageStorage localImgStorage = new LocalImageStorageStrategyFinal(new JpegCompressor(), new BlackWhiteFilter());
            ImageStorage cloudImgStorage = new CloudImageStorage(new JpegCompressor(), new BlackWhiteFilter());
            localImgStorage.Store("abc");
            cloudImgStorage.Store("abc");
        }
    }
}