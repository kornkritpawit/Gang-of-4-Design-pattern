# Adapter Pattern Conclude
- Starter project: https://github.com/utarn/csharp-pattern-adapter/tree/220d4f7d23e5522c1ff2c2e461cb71976e3b164f
- Finish project: https://github.com/utarn/csharp-pattern-adapter/tree/8d30f769bd07c602013d62c9b38e4ac3741bdaca
# Adapter Pattern Conclude
ออกแบบมาเพื่อช่วยวัตถุที่มีการใช้อินเตอร์เฟสหนึ่งสามารถแปลงการทำงานให้ทำงานร่วมกับอินเตอร์เฟสอื่นได้ 
หลักการทำงานเหมือนอแดปเตอร์ชาร์จมือถือที่แปลงไฟฟ้ากระแสสลับ 220V เป็นกระแสตรง 5V เชู่น 
เรามีคลาสที่สามารถเติมฟิลเตอร์ให้กับรูปภาพได้ แต่ไม่ใช่ทุกคนจะสร้างฟิลเตอร์เองทั้งหมด 
เราอาจต้องการใช้ฟิลเตอร์ที่พัฒนาโดยคนอื่นให้โดยแปลงฟิลเตอร์เหล่านั้นมาใช้กับคลาสที่เราขึ้นมาได้

Design 1:
- class Image: เป็นคลาสเปล่าๆ ทำหน้าที่เป็นรููปๆ นึง
- interface Filter: void Apply(Image image);
- class ImageView: private Image _image; Constructor(Image image){_image=image;}
	- pub void Apply(Filter filter){_image=image;}
- class VividFilter implement Filter: pub void Apply(Image image){Sys.CWL("Applygin vivid filter");}
- Third party Filter: Folder Avafilter=> Class Caramel.cs : เป็นเหมือน Library Filter นอก ที่โหลดมา
	- pub void Init(){ทำอะไรซักอย่างตอน Init}
	- pub void Render(Image image){Sys.CWL("Applying caramel filter")}

ตัวอย่างใน Program.cs
```
			var image1 = new Image();
            var imageView = new ImageView(image1);
            imageView.Apply(new VividFilter());
			imageView.Apply(new Caramel()); // Error (third party implement ไม่ได้)
Output:
	Applying vivid filter
```
ตัวอย่างนี้จะ Error เพราะ imageView Apply Caramel ที่เป็น thirdparty ตรงๆ ไม่ได้
ไม่ใช่ เพราะ Apply รับ Filter และการทำงานจริงเราก็จะแก้ thirdparty ไม่ได้

Design2:
- สร้าง class CaramelFilter implement Filter: pri Caramel _caramel;
	- Constructor(Caramel caramel){_caramel=caramel;}
	- pub void Apply(Image image){_caramel.Init(); _caramel.Render(image);}
	- เป็น Adapter pattern แบบ Composition
- สร้าง class CaramelAdapter implement Caramel, Filter:
	- pub void Apply(Image image){Init(); Render(image);}
	- Adapter pattern แบบ ตรงๆ (Inheritance)

ตัวอย่างใน Program.cs
```			..
            imageView.Apply(new CaramelFilter(new Caramel())); //รับเป็นทอดๆ ( Composition )
            imageView.Apply(new CaramelAdapter()); //Inheritance
            // Choose composition over Inheritance
Output: ..
	Applying caramel filter
	Applying caramel filter
```
<br> ในงานจริงใช้แบบ Composition ดีกว่า Inheritance ตรงๆ เพราะ ถ้าทำแบบตรงๆ ต้องสร้างไฟล์
ในทุกๆ thirdparty filter แต่ถ้าทำแบบ Composition ก้แก้แค่ไฟล์เดียว คือ CaramelFilter
และ ส่งค่าผ่าน Parameter อย่างเดียว
