using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace visitor_pattern
{
    public interface Operation
    {
        void Apply(HeadingNode node);
        void Apply(AnchorNode node);
        // ถ้าเพิ่ม Node ใหม่ ก็ เพิ่ม Apply ใหม่
        // ถ้าเพิ่ม function ใหม่ ก็ต้องไปเพิ่มโค้ด
        // Ex: void Apply(ParagraphNode node)fdf
    }
}