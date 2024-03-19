# Memento Pattern Conclude
- Starter project: https://github.com/utarn/csharp-design-pattern-memento/tree/5f0324597c14153dd3c54d7d0dec5d8159f12e44
- Finish project: https://github.com/utarn/csharp-design-pattern-memento/tree/ce5e8821e707e1286a038102179edc2d5a0fd446
# Memento Pattern Conclude
เป็นการแก้ปัญหาการ Undo, Redo ของ Object และสถานะต่างๆใน Object

Design 1:
- Class Editor:	pub str Title {get; pri set;} pub IList<str>Previous_Title {get;set;}
	- pub str Text {get; pri set;} pub IList<str>Previous_Text {get; set;}
	- pub int FontSize {get; pri set;} pub IList<string> Previous_FontSize{get; set;}
	- pub string FontFace {get; pri set;}
	
ข้อเสีย: ไม่ดีเพราะต้องเพิ่ม IList(HistoryList) ในทุก Property เขียนโค้ดเยอะ<br>
Design 2: using Newtonsoft.Json;
- class Editor: pub str Title {get; pri set;} pub str Text {get; pri set;}
	- pub int FontSize {get; pri set;} pub str FontFace {get; pri set;}
	- Constructor(str title, str text, int fontSize, str fontFace){
		this.Title=title;this.Text=text;this.FontSize=fontSize;this.FontFace=fontFace;}
	pub Memento<Editor> CreateState() {return new Memento<Editor>(this)}
- Class Memento<T>: เป็น class ที่ถูกสร้างเพื่อส่งต่อข้อมูล Object ไปยัง CareTaker
	- pub str Type {get;} pri readonly str _serializedData;
	- pub T Object => JsonConvert.DeserializeObject<T>(_serializedData);
	- constructor(T serializeObject){Type=typeof(T).ToString();
		_serializedData = JsonConvert.SerializeObject(serializeObject);}
		
