using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_flyweight;

namespace flyweight_pattern
{
    public class PointIconFactory
    {
        private Dictionary<IconType, PointIcon> icons = new Dictionary<IconType, PointIcon>();

        // โหลด Icon มาเก็บไว้ใน Memory
        public PointIcon GetPointIcon(IconType type) {
            if (!icons.ContainsKey(type)) { //ถ้าไม่เคยถูกใช้ ให้โหลดมาเก็บไว้ใน Memory
                var icon = new PointIcon(type, null);
                icons.Add(type, icon);
            }
            return icons[type];
        }
    }
}