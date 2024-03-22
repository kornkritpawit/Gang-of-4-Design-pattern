# Strategy Pattern Conclusion
- Starter Project: https://github.com/utarn/csharp-design-pattern-strategy/tree/913e4e5864f48219d667167f782436aada7a77ae
- Finish Project: https://github.com/utarn/csharp-design-pattern-strategy

# Strategy Pattern Conclusion
ออกแบบมาเพื่อลดความซ้ำซ้อนของการเขียนอัลกอริธืมโดยแยกส่วนของอัลกอริธึมออกมา และอนุญาตให้ระบุอัลกอริธึมเฉพาะอย่างกับวัตถุในวัตถุหนึ่งได้ เช่น ในคลาสอัพโหลดรูปภาพ เราอาจมีกระบวนการบีบอัดรูปภาพ และการใส่ฟิวเตอร์ให้รูปภาพ การใช้ Strategy pattern จะช่วยแยกอัลกอริธึมบีบอัดรูปภาพและการใส่ฟิวเตอร์ออกจากการอัพโหลดรูปภาพ อีกทั้ง หากการอัพโหลดรูปภาพมีทั้งอัพโหลดในเครื่อง และอัพโหลดขึ้นคลาวด์ คลาสการอัพโหลดทั้งสองคลาสนี้ยังแบ่งปันอัลกอริธึมร่วมกันได้ด้วย
# Strategy Pattern Conclusion
หน้าที่ของ Strategy Pattern คือ ออกแบบมาเพื่อแก้ปัญหา การสร้าง Method หรือ อัลกอรทึมซ้ำซ้อน ใน คลาส 1 คลาส ตัวอย่างเช่นขั้นตอนใน การ Upload รูปภาพเก็บไว้ใน Storage ได้แก่ 

1. Compress รูปภาพ if PNG => PNGCompress(file), if JPEG => JPEGCompress(file)
2. Filter รูปภาพ if BlackWhitefilter => applyB&Wfilter(file), if HighContrast => applyHighContrastFilter(file)

ซึ่งใน Class LocalImagestorage ที่ด้านบนจะมี Method เยอะขึ้นถ้ามี Feature มากขึ้น

## Design
- สร้าง Interface Filter, Compressor ซึ่งมี method สำหรับ การ Implement
- สร้าง class HighContrastFilter, BlackWhiteFilter ที่ Implement interface Filter
- สร้าง class JpegCompressor, PngCompressor ที่ Implement interface Compressor
- สร้าง abstract class ImageStorage เพื่อสำหรับ class LocalImageStorage และ class ที่เพิ่มขึ้นอีก 1 ตัว CloudImageStorage ในการ Inherit class property และ method ใน class แม่นี้
    - มี Property readonly Compressor, Filter
    - abstract method Store ไว้ให้ children class override method
- สร้าง Class LocalImageStorage, CloudImageStorage ที่จะ Inherit คลาส ImageStorage และ ทำการ override method Store เพื่อใส่วิธีอัพโหลดของตัวเอง

โดยการสร้าง Abstract Class จะทำให้เราสามารถ สร้าง class มาสืบทอด ImageStorage ได้หลายแบบมากขึ้น

**Program.cs**
```
ImageStorage imgStorage = new CloudImageStorage(new JpegCompressor(new BlackWhiteFilter());
imgStorage.Store("abc");
```
