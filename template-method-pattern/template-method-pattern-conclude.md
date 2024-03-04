# Template Method pattern

Starter project: https://github.com/utarn/csharp-design-pattern-template-method/tree/a945623028c95deb7886c5a01e8e742b8e2808e8
Finish project: https://github.com/utarn/csharp-design-pattern-template-method/tree/ead3fd2ad9e3cb0b8090a0eef3a33a925b784c17

# Template Method pattern
ออกแบบมาเพื่อบังคับการเขียน Method ทำให้การพัฒนาโค้ดในทีมมีทิศทางในการเขียนโค้ดที่เหมือนกัน 
เช่น การทำ logging ก่อนเริ่มทำงาน หรือ 
การ clean up ข้อมูลหลังจบการทำงาน เป็นต้น ทำให้มั่นใจได้ว่า 
โค้ดที่พัฒนาออกมาจะต้องทำงานในรูปแบบที่กำหนดเหมือนกันทั้งหมด

Start:
- Class AuditTrail: void Record(), void Stop() //บันทึก, หยุดบันทึก log
- Class TransferMoneyTask: มี constructor(AuditTrail auditTrail)
    - Execute(): auditTrail.Record(); Console.WL('Transfer'); auditTrail.Stop()
- ปัญหาคือ ถ้าเรารับ Engineer คนใหม่เข้ามาแล้ว เราก็ให้ Engineer สร้างคลาสแบบนี้มาเลยนะ
ซึ่งแบบนี้เราไม่สามารถการันตี ได้เลยว่า คนที่รับมาเขาจะทำแบบนี้

Design:
- abstract Class TemplateMethod: constructor1() {_auditTrail = new AuditTrail();}
    - constructor2(AuditTrail auditTrail){_auditTrail=auditTrail}
    - void Execute() {_auditTrail.Record(); DoExecute(); _auditTrail.Stop()}
    - protected abstract void DoExecute(); //protect เพื่อไม่ให้ใช้นอกคลาส Template
    - ให้ Class XX มา Implement , DoExecute() ให้ class อื่นมา override method
- Class TransferMoneyTask implement TemplateMethod: constructor1()=>base()
    - constructor2(AuditTrail auditTrail): base(auditTrail)
    - protected override void DoExecute(): Console.WL('Transfer Mon')
ตัวอย่างใน Program.cs
```
var transferTask = new TransferMoneyTask();
            transferTask.Execute(); //เปิดช่องทาง ให้ Call ได้ ช่องทางเดียว
            // transferTask.DoExecute();
            var reportTask = new GenerateReportTask();
            reportTask.Execute();

            // เมื่อมีงานที่ต้องบังคับการเขียนให้เป็นตามแบบ แล้วเรากลัว Programmer 
            //ไม่ยอมเขียนตามแบบนั้นให้ใช้ pattern นี้ เพราะเหมือนเป็นการบังคับให้ทำตามนี้ดด
```
- Class GenerateReportTask(): หลักการเหมือน TransferMoney แค่แก้ Override
Design นี้ เน้น ตั้ง Template แล้วให้ Dev มาสร้าง class มา implement override ในงานต่างๆ