# Facade Pattern
ออกแบบมาเพื่อซ่อนความซับซ้อนของระบบที่มีการทำงานที่ซับซ้อนและมีความยากต่อการเข้าใจ เนื่องจากมีการปฏิสัมพันธ์กันระหว่างวัตถุหลายคลาส ให้เหลือคลาสเพียงเดียวที่มีเมธอดที่ใช้เรียกการทำงานน้อยที่สุด ฟาซาสแปลว่า ด้านหน้า ซึ่งก็คือ คลาสที่ออกแบบในรูปแบบฟาซาสจะเป็นเหมือนฉากหน้าไว้เรียกใช้ โดยหากมีการแก้ไขระบบที่มีความซับซ้อน โค้ดที่มีการเรียกใช้ฟาซาสอยู่จะไม่ต้องแก้ไขหรือเปลี่ยนแปลงตาม

ตัวอย่างทำ mobile app ระบบแจ้งเตือน push notification ไปหาผู้ใช้