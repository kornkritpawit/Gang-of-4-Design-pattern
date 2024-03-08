# Visitor pattern
- Starter project: https://github.com/utarn/csharp-design-pattern-visitor/tree/0900283b7ad714c1c156a2260f2ec96bdc9b18b8
- Finish project: https://github.com/utarn/csharp-design-pattern-visitor/tree/d4ec7baef833bfc4aa81c240b06a7f6d4e2652c2

# Visitor pattern
ออกแบบมาเพื่อแยกอัลกอริธึมออกจากโครงสร้างของข้อมูล โดยทำให้สามารถเพิ่มฟีเจอร์ใหม่ให้กับข้อมูลโครงสร้างเดิมโดยที่ไม่จำเป็นต้องแก้ไข class เดิมเลย วิธีการนี้จะใช้ได้ดีก็ต่อเมื่อโครงสร้างของข้อมูลนิ่งแล้ว เช่น ใน เอกสาร HTML ประกอบ HTML node หลายตัว Visitor pattern จะช่วยให้เราต้องการเพิ่มฟีเจอร์ให้กับ tag ต่างๆ โดยที่ไม่แก้ไข Class html tag เดิมเลย ทั้งนี้เพราะ HTML tag มีจำนวนค่อนข้างคงที่จึงเหมาะสมกับ design pattern นี้