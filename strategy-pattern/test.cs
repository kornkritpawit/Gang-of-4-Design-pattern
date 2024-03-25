using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_strategy;

namespace strategy_pattern
{
    public class test
    {
        static void Main(string[] args)
        {
            ImageStorage localImgStorage = new LocalImageStorage(new JpegCompressor(), new BlackWhiteFilter());
            ImageStorage cloudImgStorage = new CloudImageStorage(new JpegCompressor(), new BlackWhiteFilter());
            localImgStorage.Store("abc");
            cloudImgStorage.Store("abc");
        }
    }
}