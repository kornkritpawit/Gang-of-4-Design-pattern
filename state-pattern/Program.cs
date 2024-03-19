using System;

namespace pattern_state
{
    class Program
    {
        static void Main(string[] args)
        {
            // var newCanvas = new Canvas();
            // newCanvas.CurrentToolType = ToolType.BRUSH;
            // newCanvas.mouseDown();
            // newCanvas.mouseUp();

            // //BrushTool.cs, BucketTool.cs, CanvasState.cs, EraseTool.cs, SelectionTool.cs, Tool.cs, ToolType.cs
            // var newCanvas = new CanvasStatePt();
            // newCanvas.CurrentToolType = new BrushTool();
            // newCanvas.mouseDown();
            // newCanvas.mouseUp();         
            // newCanvas.CurrentToolType = new SelectionTool();
            // newCanvas.mouseDown();
            // newCanvas.mouseUp();            
            // newCanvas.CurrentToolType = new BucketTool();
            // newCanvas.mouseDown();
            // newCanvas.mouseUp();

            //Open Closed Design: Open ore extension/ CLose for modification
            // เปิดให้ขยาย (เพิ่ม feature ยังคับใน interface) ปิดไม่ให้แก้ไขใน Canvas
            // เพิ้ม Tool ใหม่ก็สร้าง Class ใหม่
            // ลด การเขียน ifelse series ลดโอกาสเขียนโค้ดผิด

            // StopWatchStatePt.cs, StopWatchState.cs, StoppedState.cs , RunningState.cs
            var sw = new StopWatch(); //บาง feature ไม่จำเป็นต้องทำ State เพราะจะ ยุ่งยาก
            // นาฬิกา มีแค่ run stop ไม่มีว่าจะเพิ่ม state เพิ่มจริงๆก็ไม่ต้องใช้ state ถ้ามี tool เยอะก็ใช้ดี
            // var sw = new StopWatchStatePt();
            sw.Click();
            sw.Click();
            sw.Click();

        }
    }
}