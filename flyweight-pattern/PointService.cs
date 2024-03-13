using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using pattern_flyweight;
using Point = pattern_flyweight.Point;

namespace flyweight_pattern
{
    public class PointService //ใช้เรียก Point จาก Database มา
    {
        public IList<Point> GetPoints() {
            IList<Point> points = new List<Point>();
            var point = new Point(1,2, IconType.CAFE, null);
            points.Add(point);
            return points;
        }
    }
}