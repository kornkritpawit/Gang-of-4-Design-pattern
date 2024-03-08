# Mediator Pattern Conclude
Starter project: https://github.com/utarn/csharp-design-pattern-mediator/tree/1ed57f137e1e63f50a40d266e458201bbf325efe
Finish project: https://github.com/utarn/csharp-design-pattern-mediator/tree/43d6ea566fd492e317825465b76d6c36628d10a7
# Mediator Pattern
ออกแบบมาให้เป็นตัวกลางที่เก็บการปฏิสัมพันธ์กันระหว่างวัตถุที่มาจากหลายๆคลาส 
โดยที่ไม่จำเป็นต้องไปแก้ไขโค้ดในคลาสของวัตถุที่ปฏิสัมพันธ์ด้วย mediator pattern 
นี้จะช่วยให้คลาสแต่ละคลาสไม่จำเป็นต้องรู้จักกัน ซึ่งเป็นการลดการพึ่งพาหรือ dependency ระหว่างคลาส 
<br> มีตัวอย่างคลิป ASP.netcore ตัว Controller MVC ต้องโหลด Database 
หลายอย่างทำให้ controller ใหญ่ หนา ตัว mediator นี้จะทำให้โค้ดเล็กลง

Problem: Winform หน้าจอโต้ตอบ (ArticleDialogBox) => ListBox สำหรับ เลือกArticle มาแสดงใน TextBox, หรือ
แก้ไขข้อความใน TextBox มีปุ่ม Save (Button) สำหรับ เซฟ หน้าจอโต้ตอบ ถ้า TextBox ไม่ Empty

Design: แบบไม่ดี Ex
	- Class TextBoxBad
		- pri str _text; pri Button _saveButton, public
		- pub str Text get; set{_text=value; เช็คถ้ามี text => savebutton จะenable}
		- ไม่ดีเพราะ textbox คุยตรงกับ Button และ button คุยตรงกับ text, Listbox โค้ดจะซับซ้อน
Design1:
	- class UIControl: //ทำหน้าที่ Mediator
		- protected DialogBox _owner;
		- constructor(DialogBox owner){_owner=owner;}
	- abstract class DialogBox: เป็น parent class ของหน้าจอเปล่า
		- pub abstract void OnChanged(UIControl control);
	- class Button implement UIControl:
		- consturctor(DialogBox owner):base(owner);
		- pub bool IsEnabled{get; set{_isEnabled=value;
			_owner.OnChanged(this);} //this ตัวเองเป็น UIControl
	- class TextBox implement UIControl:
		- pri string _text; constructor(DialogBox owner)
		- pub string Text{get; set{_text=value;_owner.OnChanged(this);}
	- class ListBox implement UIControl:
		- pri str _selection; constructor(DialogBox owner) : base(owner)
		- pub str Selection{get; set{_selection=value;_owner.OnChanged(this);
	- class ArticleDialogBox implement DialogBox: เป็นคลาสหลักโปรแกรมนี้
		- pri ListBox _articleListBox;, pri TextBox _titleTextBox; pri Button _saveButton;
		- constructor(){_articleListBox=new ListBox(this);_titleTextBox=new TextBox(this;
			_saveButton=new Button(this);
		- pub void SimulateChanges() {_articleListBox.Selection="Article 1";
		Cons.WL("Listbox; "+_articleListBox.Selection);Cons.WL("Textbox: "+_titleTextBox.Text);
		Cons.WL("Button : "+ _saveButton.IsEnabled);
		- pub override void OnChanged(UIControl control){
			if(control==_articleListBox){articleChanged();}
			elseif(control==_titleTextBox){titleChanged();}
		- pri void articleChanged(){_titleTextBox.Text=_articleListBox.Selection;
			_saveButton.IsEnabled=True}
		- pri void titleChanged() {var content = _titleTextBox.Text;
			var isEmpty = string.IsNullOrEmpty(content); _saveButton.IsEnabled = !isEmpty;
ตัวอย่างใน Program.cs
```
            var articleDialog = new ArticleDialogBox();
            articleDialog.SimulateChanges();
	Output:
	Listbox: Article 1
	Textbox : Article 1
	Button : True (
	== ถ้า _titleTextBox.Text = ""; ==
	Listbox: Article 1
	Textbox :
	Button : False
```
Design: version นำ dotnetcore Observer pattern มาช่วย
	- Class UIControl:
		- pri List<Action> _eventHandlers=new List<Action>(); //Action คือ function
		- pub void AddEventHandler(Action observer){_evenHandlers.Add(observer);}
		-protect void NotifyEventHandlers() { foreach(var eventHandlers in _eventHandlers){
			eventHandlers.Invoke();}}
	- Class Button, Listbox, Textbox: ลบ Constructor ออก, เปลี่ยน _owner.OnChanged เป็น NotifyEventHandlers();
	- Class ArticleDialogBox *ไม่มี implement*: ลบ override void Onchanged ออก
		- Constructor(): _articleListBox = new ListBox();
			_articleListBox.AddEventHandler(articleChanged); _titleTexBox = new TextBox();
			_titleTexBox.AddEventHandler(titleChanged); _saveButton = new ButtonObserver();
	- อื่นๆเหมือนเดิม
