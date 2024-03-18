using System;

namespace pattern_state
{

    public class CanvasStatePt
    {
        public Tool CurrentToolType { get; set; }
        public void mouseDown()
        {
            CurrentToolType.mouseDown();
        }

        public void mouseUp()
        {
            CurrentToolType.mouseUp();
        }
    }
}