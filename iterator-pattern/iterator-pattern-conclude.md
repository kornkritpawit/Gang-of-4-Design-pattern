# Iterator pattern:
ออกแบบมาเพื่อเข้าถึงสมาชิกที่เป็นลิสต์ หรืออาร์เรย์ในวัตถุหนึ่ง โดยที่หากวัตถุนั้นเปลี่ยนโครงสร้างภายในในภายหลัง โค้ดการเข้าถึงสมาชิกยังคงเหมือนเดิมไม่เปลี่ยนแปลง เช่น ในเว็บเบราเซอร์ เราเก็บรายการของเว็บไซต์ที่เข้าชมไว้ ด้วย linked List หากเราเป็นโครงสร้างเป็น array ที่เก็บเพียง 10 เว็บไซต์ล่าสุดแทน โค้ดการดูรายการประวัติเว็บไซต์จะต้องไม่เปลี่ยนแปลง
