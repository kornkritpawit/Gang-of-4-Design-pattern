# Flyweight Pattern Conclude
- Starter project: https://github.com/utarn/csharp-pattern-flyweight/tree/14659459bc0fb8fec7361892c396edd084133183
- Finish project: https://github.com/utarn/csharp-pattern-flyweight/tree/fb78d20e31549e5973e48a01dbe52a1c155e47f5
# Flyweight Pattern Conclude
ออกแบบเพื่อลดการใช้หน่วยความจำด้วยการแบ่งปันข้อมูลระหว่างวัตถุที่เหมือนกันและ
เก็บข้อมูลไว้ในหน่วยความจำเป็นชุดเดียว โดยวัตถุจะเป็นข้อมูลบางส่วนที่สามารถใช้งานร่วมกันได้
และถูกเก็บไว้ในโครงสร้างหรือคลาสที่แยกออกมา ยกตัวอย่างเช่น 
ในแอปพลิเคชันแผนที่บนมือถือ จะมีจุดที่ระบุสถานที่แต่ละประเภทเช่น 
ร้านอาหาร โรงเรียน โรงพยาบาลไว้หลายจุดบนแผนที่ 
โดยที่หากแต่ละจุดเป็นสถานที่ประเภทเดียวกันจะมีไอคอนแสดงบนแผนที่เหมือนกัน

Design 1:
- pub enum IconType {CAFE, SCHOOL, HOSPITAL}
- class Point: pri int x; pri int y; pri IconType type; pri byte[] icon;
	- constructor(int x, int y, IconType type, byte[] icon) {
		this.x=x; this.y=y; this.type=type; this.icon=icon;}
	- pub void Draw() {Sys.cwl($"{type} at ({x}, {y})");}
- class PointService: pub IList<Point> GetPoints(){IList<Point> points=new List<Point>()
	var point = new Point(1,2, IconType.CAFE, null); points.Add(point); return points;}
	
ตัวอย่างใน Program.cs
```
	var service = new PointService();
	foreach (var point in service.GetPoints()) { point.Draw(); }
Output: 
CAFE at (1, 2)
```
ข้อเสีย: 
- Point แต่ละจุดที่เก็บ รูป icon(byte[]) มีขนาด 20 KB
- ถ้าโปรแกรม มี 1000 point ก็เท่ากับว่ากิน memory 20MB และแต่ละ Point
ก็จะมีแต่ icon ซ้ำๆ ทำให้สิ้นเปลืองทรัพยากร

Design 2:
- สร้าง class PointIcon: pub IconType type {get;} pub byte[] icon {get;} //วิธีทำreadonly
	- constructor(IconType type, byte[] icon) {this.type=type;this.icon=icon;}
- class Point: pri int x; pri int y; pri PointIcon icon;
	- constructor(int x, inty, PointIcon icon){this.x=x;this.y=y;thix.icon=icon}
	- pub void Draw() {Sys.cwl($"{type} at ({x}, {y})");}
	- เก็บ Icon แยก Structure
- class PointIconFactory: pri Dictionary<IconType, PointIcon> icons = 
	new Dictionary<IconType, PointIcon>
	- pub PointIcon GetPointIcon(IconType type) {if(!icons.ContainsKey(type)){
		var icon=new PointIcon(type, null); icons.Add(type, icon);}
		return icons[type]}
	- class นี้เรียก รูป Icon มาเก็บไว้ใน Memory ถ้า type ไหนยังไม่ถูกเรียก ก็เรียกมาเก็บ
		ถ้ามีอยู่แล้ว ก็ ส่งให้ Service ที่ขอใช้ //Reuse Icon
- class PointService: pri PointIconFactory factory;
	- constructor(PointIconFactory factory){this.factory=factory;}
	- pub IList<Point> GetPoints() {IList<Point> points=new List<Point>();
		var point = new Point(1,2, factory.GetPointIcon(IconType.CAFE));
		points.Add(point); return points}

ตัวอย่างใน Program.cs
```
            var factory = new PointIconFactory();
            var service = new PointService(factory);
            foreach (var point in service.GetPoints()) {
                point.Draw();
            }
Output:
CAFE at (1, 2)
```


