# Observer Pattern Conclude
- Starter project: https://github.com/utarn/csharp-design-pattern-observer/tree/41a9e5d9552819f0dca90267a589fd29d5f87e96
- Finish project: https://github.com/utarn/csharp-design-pattern-observer/tree/1835757e527912a269d1eece34383398d7bdb38c

# Observer Pattern Conclude
ออกแบบมาเพื่อให้การเปลี่ยนแปลงของวัตถุหนึ่งสามารถเผยแพร่ไปยังวัตถุอื่น 
ที่ตอบรับหรือสังเกตุความเปลี่ยนแปลงนั้น เรามีฟิลด์ของข้อมูลที่เก็บตัวเลขไว้ 
แล้วตัวเลขเหล่านี้ถูกนำไปหาผลรวม หรือแสดงเป็นกราฟ ทันทีที่เราเปลี่ยนแปลงตัวเลขใน excel ค่าผลรวมและกราฟก็จะอัพเดทเปลี่ยนแปลงไปตามตัวเลขที่เราแก้ไขใหม่

Design (แบบสะดวก):
- interface Observer : void Update() //Observer Pattern
- Class Subject: เป็น Super class ให้ class DataSource มาสืบทอด //เป็นเหมือน Topic ของ งาน
	- private List<ObServer> _observers; Constructor() {_observers = new List<ObServer>()}
	- pub void AddObserver(Observer obServer) {_observers.Add(obServer)}
	- pub void RemoveObserver(ObServer obServer){_observers.Remove(obServer);}
	- pub void NotifyObserver() {foreach(observer in _observers){observer.Update()}}
- Class DataSource implement Subject: // Data สำหรับ Excel และวาด Chart
	- pri int _data; pub int get {return _data;} set {_data=value; NotifyObserver()}
- Class PullingSpreadSheet implement Observer: //pulling เพราะ pull ตรงจาก Datasource
	- pri DataSource _dataSource; Constructure(DataSource dataSoure){set _dataSource}
	- pub void Update() {Console.WL("Got Notified from datasource: "+_dataSource.Data)}
- Class PullChart implement Observer: หลักการเหมือน

ตัวอย่าง Program.cs
```
            var sheet3 = new PullingSpreadSheet(dataSource1);
            var sheet4 = new PullingSpreadSheet(dataSource1);
            var chart2 = new PullChart(dataSource1);
            dataSource1.AddObserver(sheet3);
            dataSource1.AddObserver(sheet4);
            dataSource1.AddObserver(chart2);
            dataSource1.Data = 20;
      -Output-: Got notified from datasource: 20
            Got notified from datasource: 20 
            Got notified from datasource: 20
```
Design (แบบไม่สะดวก):
- interface Observer<T> : void Update(T value)
- class Subject: pri List<ObServer<int>> _observers;
	- constructor(){_observer = new List<ObServer<int>>()}
	- void AddObServer(ObServer<int> obServer){_observers.Add(obServer)}
	- void RemoveObserver(ObServer<int> obServer){_observers.Remove(obServer)}
	- void NotifyObserver(int value){foreach(var observer in _observers){observer.Update(value)}}
- class DataSource: เหมือนเดิม ยกเว้น set{_data=value; NotifyObserver(_data)}
- Class SpreadSheet implement ObServer<int>: pub void Update(){Console.WL("..")}
	- pub void Update(int value) {Console.WL("Got notified.."+value)}
- Class Chart เหมือน SpreadSheet
ตัวอย่าง Program.cs
```
            var dataSource1 = new DataSource();
            var sheet1 = new SpreadSheet();
            var sheet2 = new SpreadSheet();
            var chart1 = new Chart();

            dataSource1.AddObserver(sheet1);
            dataSource1.AddObserver(sheet2);
            dataSource1.AddObserver(chart1);
            dataSource1.Data = 10;
    Output: เหมือนกับ อันก่อนหน้า
``` ที่แบบนี้ไม่ดีเพราะ เป็นการส่ง Data ไปหา Observer ซึ่งท่า ชนิดของ Data มีการเปลี่ยน
เราก็ต้องแก้ไขไฟล์ หลายไฟล์ล้มเป็น Domino ดังนั้น ดึงข้อมูลจาก Data ตรงๆ ง่ายกว่า
