using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using pattern_flyweight;
using Point = pattern_flyweight.Point;

namespace flyweight_pattern
{
    public class PointServiceFw //ใช้เรียก Point จาก Database มา
    {
        private PointIconFactory factory;

        public PointServiceFw(PointIconFactory factory)
        {
            this.factory = factory;
        }

        public IList<PointFw> GetPoints() {
            IList<PointFw> points = new List<PointFw>();
            // ให้ factory ไปดึงเอารูปที่เคยถูกเอามาใช้แล้ว
            var point = new PointFw(1,2, factory.GetPointIcon(IconType.CAFE));
            points.Add(point);
            return points;
        }
    }
}