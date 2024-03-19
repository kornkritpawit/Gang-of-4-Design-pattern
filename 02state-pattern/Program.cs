using System;

namespace pattern_state
{
    class Program
    {
        static void Main(string[] args)
        {
            // var newCanvas = new Canvas();
            // newCanvas.CurrentToolType = new BucketTool();
            // newCanvas.mouseDown();
            // newCanvas.mouseUp();

            // var sw = new StopWatchEasy();
            // sw.Click();
            // sw.Click();
            // sw.Click();
            
            //Open Closed Design: Open ore extension/ CLose for modification

            var sw2 = new StopWatch();
            sw2.Click();
            sw2.Click();
            sw2.Click();
        }
    }
}