# Bridge Pattern Conclude
- Starter project: https://github.com/utarn/csharp-pattern-bridge/tree/62f304259781a3331f82b81bc6c6758d88d02cbd
- Finish project: https://github.com/utarn/csharp-pattern-bridge/tree/e34abf485dfa293520aa902a43e7c70acf97e54b

# Bridge Pattern Conclude
ช่วยลดความซ้ำซ้อนของการเขียนโค้ดเมื่อเกิดโครงสร้างที่ขยายออกไปสองทิศทางโดยอิสระต่อกัน 
เช่น โปรแกรมรีโมทควบคุมเครื่องใช้ไฟฟ้าในแอปพลิเคชันมือถือที่สามารถใช้ได้กับเครื่องใช้ไฟฟ้าหลายประเภท 
และหลายยี่ห้อแบบ Universal ดังนั้น โครงสร้างที่เขียนจะเกิดการขยายออกไปสองทิศทาง 
คือ ด้านหนึ่งเขียนเพื่อสนับสนุนอุปกรณ์ไฟฟ้าหลายชนิด และอีกด้านหนึ่งเขียนเพื่อสนับสนุนอุปกรณ์ไฟฟ้าหลายยี่ห้อ 
ซึ่งถ้าหากออกแบบไม่ดีจะมีตำแหน่งที่เขียนโค้ดซ้ำไปซ้ำมาหลายที่

Design1:<br>
- abstract class RemoteControl: pub abstract void TurnOn(); pub abstract void TurnOff();
- abstract class AdvancedRemoteControl inherit RemoteControl:
	- pub abstract void SetChannel(int number);
- class SonyRemoteControl inherit RemoteControl: 
	- pub override void TurnOff(){sys.cwl("Sony : Turn off");}
	- pub override void TurnOn(){sys.cwl("Sony : Turn on")}
- class SonyAdvancedRemoteControl inherit AdvancedRemoteControl:
	- pub override void SetChannel(int number) {sys.cwl("Sony : Set channel to "+number);}
	- pub override void TurnOff(){sys.cwl("Sony : Turn off");}
	- pub override void TurnOn(){sys.cwl("Sony : Turn on")}
	
ข้อเสียของ แบบนี้:
- RemoteControl(TurnOn, TurnOff) => SonyRemoteControl, SamsungRemoteControl
- AdvancedRemoteControl(+SetChannel) => SonyAdvancedRemoteControl,SamsungAdvancedRemoteControl
- MovieRemoteControl(Play, Pause, Rewind) => SonyMovieRemoteControl, SamsungMovieRemoteControl
- 1 brand --> add 3 classes Samsung =>RemoteCtrl,AdvanceRemoteCtrl,MovieRemoteCtrl
- เพิ่ม 10 brands --> add 30 classes,มีการใช้โค้ดซ้ำซ้อนเช่น SonyAdvancedRemoteControl,SonyRemoteControl

Design2:<br>
- เพิ่ม Interface Device: void TurnOn(); void TurnOff() void SetChannel(int number);
- class RemoteControl: protected Device device; constructor(Device device){this.device=device;}
	- pub void TurnOn(){device.TurnOn();} pub void TurnOff(){device.TurnOff()}
- class AdvancedRemoteControl inherit RemoteControl:
	- constructor(Device device) : base(device) {}
	- pub void SetChannel(int number){device.SetChannel(number);}
- class SonyBrand implement Device: 
	- pub void SetChannel(int number) {sys.cwl("Sony : Set channel to "+number);}
	- pub void TurnOff(){sys.cwl("Sony : Turn off");}
	- pub void TurnOn(){sys.cwl("Sony : Turn on")}
- class SamsungBrand implement Device:
	- pub void SetChannel(int number) {sys.cwl("Samsung : Set channel to "+number);}
	- pub void TurnOff(){sys.cwl("Samsung : Turn off");}
	- pub void TurnOn(){sys.cwl("Samsung : Turn on")}

ตัวอย่างใน Program.cs
```
            var SonyRemoteControl = new RemoteControlB(new SonyBrand());
            var SamsungRemoteControl = new RemoteControlB(new SamsungBrand());
            var SamsungAdvanceRemoteControl = new AdvancedRemoteControlB(new SamsungBrand());
            var SonyAdvanceRemoteControl = new AdvancedRemoteControlB(new SonyBrand());
            SonyRemoteControl.TurnOn();
            SamsungRemoteControl.TurnOn();
            SamsungAdvanceRemoteControl.TurnOn();
            SonyAdvanceRemoteControl.TurnOn();
            SamsungAdvanceRemoteControl.SetChannel(5);
            SonyAdvanceRemoteControl.SetChannel(5);
Output:
Sony : Turn on
Samsung : Turn on
Samsung : Turn on
Sony : Turn on
Samsung : Set channel to 5
Sony : Set channel to 5
```<br>
Conclude Design2:
- Device => SonyBrand, SamsungBrand
- RemoteControl => AdvanceRemoteControl, MovieRemoteControl
- ลดการ Reuse Code โดยใช้ Composition 
- var SamsungAdvanceRemoteControl = new AdvancedRemoteControl(new SamsungBrand()); 
- var SamsungRemoteControl = new RemoteControl(new SamsungBrand());
- มี 2 สายการพัฒนา อันนึงเป็น Feature เช่น RemoteControl จะมี Function อะไร
	อีกอันเป็น ประเภทยี่ห้อ รุ่นว่ามีรุ่นอะไรบ้าง เช่น Datastorage แบบไหน provider ยี่ห้ออะไร