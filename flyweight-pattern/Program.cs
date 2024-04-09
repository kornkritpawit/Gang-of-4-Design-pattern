using System;
using flyweight_pattern;

namespace pattern_flyweight
{
    class Program
    {

        // static void Main(string[] args)
        // {
        //     var service = new PointService();
        //     foreach (var point in service.GetPoints()) {
        //         point.Draw();
        //     }
        // }

        static void Main(string[] args)
        {
            var factory = new PointIconFactory();
            var service = new PointService(factory);
            foreach (var point in service.GetPoints()) {
                point.Draw();
            }
        }
    }
}