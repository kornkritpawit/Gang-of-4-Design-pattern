using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_flyweight;

namespace flyweight_pattern
{
    public class PointIcon
    {
        public IconType type {get;} //4 bytes {get;} is readonly
        // public IconType type {get; private set;} set ได้เฉพาะ private method
        public byte[] icon {get;} // 20 KB ==> 20MB

        public PointIcon(IconType type, byte[] icon)
        {
            this.type = type;
            this.icon = icon;
        }
    }
}