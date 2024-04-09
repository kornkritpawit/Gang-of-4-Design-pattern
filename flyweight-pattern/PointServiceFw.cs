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
        private PointIconFactory factory;
        public PointService(PointIconFactory factory)
        {
            this.factory = factory;
        }
        public IList<Point> GetPoints() {
            IList<Point> points = new List<Point>();
            // ให้ factory ไปดึงเอารูปที่เคยถูกเอามาใช้แล้ว
            var point = new Point(1,2, factory.GetPointIcon(IconType.CAFE));
            points.Add(point);
            return points;
        }
    }
}