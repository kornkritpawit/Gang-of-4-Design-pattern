using System;

namespace pattern_state
{
    // Bad Methos
    public class Canvas
    {
        public ToolType CurrentToolType { get; set; }
        public void mouseDown()
        {
            if (CurrentToolType == ToolType.SELECTION)
            {
                Console.WriteLine("Selection icon");
            }
            else if (CurrentToolType == ToolType.BRUSH)
            {
                Console.WriteLine("Brush icon");
            }
            else if (CurrentToolType == ToolType.ERASER)
            {
                Console.WriteLine("Eraser icon");
            }
        }
        public void mouseUp()
        {
            if (CurrentToolType == ToolType.SELECTION)
            {
                Console.WriteLine("Draw a rectangle");
            }
            else if (CurrentToolType == ToolType.BRUSH)
            {
                Console.WriteLine("Draw a line");
            }
            else if (CurrentToolType == ToolType.ERASER)
            {
                Console.WriteLine("Erase something");
            }
        }
        //ถ้าเพิ่ม Keyup, Keydown ก็ต้องเพิ่มเงื่อนไขซ้ำๆ เต็มไปหมด
    }
}