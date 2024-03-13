# Memento Pattern Conclude
- Starter project: https://github.com/utarn/csharp-design-pattern-memento/tree/5f0324597c14153dd3c54d7d0dec5d8159f12e44
- Finish project: https://github.com/utarn/csharp-design-pattern-memento/tree/ce5e8821e707e1286a038102179edc2d5a0fd446
# Memento Pattern Conclude
เป็นการแก้ปัญหาการ Undo, Redo ของ Object และสถานะต่างๆใน Object
- Class Editor
    Property: Title, Text

1. วิธีแก้ แบบไม่ดี เพิ่ม HistoryListTitle, HistoryListText
(ไม่ดีเพราะต้องเพิ่ม HistoryList ในทุก Property)

Design Final:
- Class Memento 
    - เป็น class ที่ถูกสร้างเพื่อส่งต่อข้อมูล Object ไปยัง CareTaker

- Class CareTaker
    - มีหน้าที่เก็บ histories ของ State ใน Object
    - HistoryList<Memento>
    - lastIndex (start = -1)
    - Undo() return HistoryList[lastIndex--]
            - (รีเทิร์น เสร็จแล้วลด 1 index)
    - Redo() return HistoryList[lastIndex++]
            - (รีเทิร์น เสร็จแล้วเพิ่ม 1 index)
    - PushMemento(Memento) ลบประวัติ Redo ก่อนหน้า และ push memento state ใหม่

- Class Editor
    - Property: Title, Text
    - CreateState() => Memento<Editor
    - RestoreState(Memento Editor) รับ Memento มาแล้ว set Property
