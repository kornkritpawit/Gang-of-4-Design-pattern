# Composite Pattern Conclude
- Starter project: https://github.com/utarn/csharp-pattern-composite/tree/79d90b4e288fc7b34c3bffb60df05385c40f76f0
- Finish project: https://github.com/utarn/csharp-pattern-composite/tree/60ab0d11430d48d03866371932d4891e896cf544

# Composite Pattern Conclude
ออกแบบมาเพื่อจัดกลุ่มของวัตถุเพื่อให้ดำเนินการได้เหมือนวัตถุประเภทเดียวกัน 
จุดมุ่งหมายของคำว่า Composite ก็คือ Compose ที่แปลว่าประกอบด้วย 
เป็นการจัดกลุ่มวัตถุเหมือนโครงสร้างต้นไม้ เช่น มีวัตถุเป็นสีเหลี่ยม วัตถุวงกลม 
ที่สามารถจัดกลุ่มเพื่อเคลื่อนย้าย หรือย่อขยายขนาดของวัตถุที่อยู่ในกลุ่มเดียวกันไปพร้อมกันได้ 
การเขียนแบบ Composite pattern จะช่วยให้เราสามารถจัดกลุ่มของรูปวาด 
และกลุ่มของกลุ่มรูปวาด เป็นชั้นๆได้อย่างง่ายดาย <br>
Design1:
- class Shape: pub void Render(){Sys.CWL("Render Shape")}
- class Group: pri List<Shape> _shapes; Constructor(){_shapes=new List<Shape>();}
	- pub void Add(Shape shape){_shapes.Add(shape);}
	- pub void Render() {foreach(var shape in _shapes){shape.Render();}}
	
ตัวอย่างใน Program.cs:
```
            var shape1 = new Shape();
            var shape2 = new Shape();
            var group1 = new Group();

			group1.Add(shape1); group1.Add(shape2);
			var shape3 = new Shape(); var shape4 = new Shape()
			var group2 = new Group()
			group2.Add(shape3); group2.Add(shape4);
            // var topGroup = new Group(); //เอา Group ใส่ group ไม่ได้
            topGroup.Add(group1); //Error
            topGroup.Add(group2);
```
ข้อเสีย เอา Group ใส่ Group ไม่ได้<br>
Design2:
- แก้ Class Group: pri List<object> _objects; Constructor(){_objects=new List<object>()}
	- pub void Add(object obj){_objects.Add(obj);}
	- pub void Render() {foreach (var obj in _objects) {if (obj is Shape) {
		((Shape)obj).Render()} if (obj is Group){((Group)obj).Render()}}}
<br>ตัวอย่างใน Program.cs
``` //บรรทัดก่อนหน้าเหมือนเดิม var shape.. group..
			
            topGroup.Add(group1);
            topGroup.Add(group2);
			topGroup.Render();
		Output:
		Render Shape
		Render Shape
		Render Shape
		Render Shape
```
ข้อเสีย คือ ถ้าเพิ่ม ชนิด Object เข้าไปใน Group ก็ต้องเพิ่ม if (obj is ..) เข้าไปใน Class Group <br>
Design Final:
- เพิ่ม Interface Component: pub void Render; void Move(); //เพิ่ม feature ใหม่
- แก้ Class Shape implement Component: - เพิ่ม pub void Move(){Sys.CWL("Moving Shape")}
- แก้ Class Group implement Component: pri List<Component> _components;
	- Constructor(){_components = new List<Component>()}
	- pub void Add(Component obj){_components.Add(obj);}
	- pub void Move() {foreach(var component in _components){component.Move()}}
	- pub void Render() {foreach(var component in _components){component.Render();}}
<br>ตัวอย่างใน Program.cs
```	\\ทำเหมือนเดิม
    topGroup.Render();
    topGroup.Move();
Output:
Render Shape
Render Shape
Render Shape
Render Shape
Moving Shape
Moving Shape
Moving Shape
Moving Shape
```

