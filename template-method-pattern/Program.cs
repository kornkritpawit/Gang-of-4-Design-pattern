using System;
using template_method_pattern;

namespace pattern_template_method
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var transferTask = new TransferMoneyTask();
            transferTask.Execute(); //เปิดช่องทาง ให้ Call ได้ ช่องทางเดียว
            // transferTask.DoExecute(); // ทำไม่ได้ เพราะ function เป็น protect
            var reportTask = new GenerateReportTask();
            reportTask.Execute();

            // เมื่อมีงานที่ต้องบังคับการเขียนให้เป็นตามแบบ แล้วเรากลัว Programmer ไม่ยอมเขียนตามแบบนั้นให้ใช้ pattern นี้ เพราะเหมือนเป็นการบังคับให้ทำตามนี้ดด
        }
    }
}