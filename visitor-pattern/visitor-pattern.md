# Visitor pattern
- Starter project: https://github.com/utarn/csharp-design-pattern-visitor/tree/0900283b7ad714c1c156a2260f2ec96bdc9b18b8
- Finish project: https://github.com/utarn/csharp-design-pattern-visitor/tree/d4ec7baef833bfc4aa81c240b06a7f6d4e2652c2

# Visitor pattern
ออกแบบมาเพื่อแยกอัลกอริธึมออกจากโครงสร้างของข้อมูล โดยทำให้สามารถเพิ่มฟีเจอร์ใหม่ให้กับข้อมูลโครงสร้างเดิม
โดยที่ไม่จำเป็นต้องแก้ไข class เดิมเลย วิธีการนี้จะใช้ได้ดีก็ต่อเมื่อโครงสร้างของข้อมูลนิ่งแล้ว 
เช่น ใน เอกสาร HTML ประกอบ HTML node หลายตัว Visitor pattern 
จะช่วยให้เราต้องการเพิ่มฟีเจอร์ให้กับ tag ต่างๆ โดยที่ไม่แก้ไข Class html tag เดิมเลย ทั้งนี้เพราะ HTML tag 
มีจำนวนค่อนข้างคงที่จึงเหมาะสมกับ design pattern นี้

Design 1 Starter bad:
- interface HtmlNode: void Highlight(); void Plaintext()
- class HtmlDocument:
	- pri readonly List<HtmlNode> _nodes;
	- constructor()=> _nodes = new List<HtmlNode>();
	- void Add(HtmlNode node){_nodes.Add(node);}
	- pub void Highlight(){foreach(var node in _nodes)
		{node.Highlight()}}
	- pub void PlainText() เหมือน Highlight()
- class AnchorNode implement HtmlNode:
	- pub void Highlight(){Console.WL("highlight-anchor");}
	- pub void PlainText() {Console.WriteLine("text-anchor")}
- class HeadingNode implement HtmlNode:
	- pub void Highlight(){Console.WL("highlight-heading")}
	- pub void PlainText() {Console.WriteLine("text-heading")}
ตัวอย่างใน Program.cs
```
            var htmlDocument = new HtmlDocument();
            htmlDocument.Add(new HeadingNode());
            htmlDocument.Add(new AnchorNode());
            htmlDocument.Highlight();
Output:
	highlight-heading
	highlight-anchor
```
ปัญหาคือ ถ้ามี feature ใหม่เข้ามา เราต้องไปแก้ที่ไฟล์ Interface HtmlNode
และ แก้ไข class เพิ่ม function ทุก class ที่ implement 
ต้องไปแก้ ทุก class ทุก node
- strategy pt จะแยก algorithm ออกไปคนละส่วน
- visitor pt จะแยก algorithm ออกไปรวมในส่วนเดียวกันHighlight(), 
	ควรอยูที่เดียวกัน และ Plaintext ก็ควรอยู่ที่เดียวกัน

Design Finish:
- เพิ่ม interface Operation: 
- void Apply(HeadingNode node);,void Apply(AnchorNode node);
- แก้ interface HtmlNode: ลบ Highlight(), PlainText() ออก
	- เพิ่ม void Execute(Operation operation);
- แก้ Class AnchorNode, HeadingNode implement HtmlNode
	- ลบ Highlight(), Plaintext() ออก
	- เพิ่ม pub void Execute(Operation operation){
			operation.Apply(this)}
- เพิ่ม class HighlightOperation implement Operation
	- pub void Apply(HeadingNode node){Console.WL("highlight-heading")}
	- pub void Apply(AnchorNode node){Console.WL("highlight-anchor")}
- เพิ่ม class PlainTextOperation implement Operation
	- pub void Apply(HeadingNode node){Console.WL("text-heading")}
	- pub void Apply(AnchorNode node){Console.WL("text-anchor")}	
- แก้ Class HtmlDocument: ลบ function Highlight(), Plaintext
	- เพิ่ม pub void Execute(Operation operation){
			foreach( var node in _nodes){node.Execute(operation);}}
ตัวอย่างใน Program.cs
```
            var htmlDocument = new HtmlDocument();
            htmlDocument.Add(new HeadingNode());
            htmlDocument.Add(new AnchorNode());
            htmlDocument.Execute(new HighlightOperation());
            htmlDocument.Execute(new PlainTextOperation());
Output:
highlight-heading
highlight-anchor
text-heading
text-anchor
```
ถ้า โครงสร้างคงที่ ก็ ใช้ Visitor pattern ได้ ถ้าโครงสร้างไม่คงที่ 
ก็ต้องเพิ่ม ที่ Interface Operation -Apply(... node); แล้วก็ไปเพิ่ม operation