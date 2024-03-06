# Observer Pattern NetCore
Starter project: https://github.com/utarn/csharp-design-pattern-observer-netcore/tree/40549d86cd49d9965c89697b68b1367e6b40ef24

Finish project: https://github.com/utarn/csharp-design-pattern-observer-netcore/tree/dc266b4c406ff7628f654c7cc93b5a681bb1529f

IObserver: รับข้อมูล 
IObservable เป็นProvider

# Observer Pattern NetCore
ออกแบบมาเพื่อ Watch การเปลี่ยนแปลงของวัตถุนึง แล้วให้วัตถุที่ สังเกตุอยู่ตอบรับความเปลี่ยนแปลงนั้น
ใน .netcore มี interface ที่ช่วยให้เราสามารถสร้าง observer pattern โดยมีคุณสมบัติ
Push notification และเพิ่มคุณสมบัติการตอบรับข้อมูล และยกเลิกการตอบรับข้อมูล
โดยในงานนี้จะเป็นการอัพเดทข้อมูลหุ้น

Design กรณี StockProvider =Subscribe=> Stockbar:
- Class Stock: เก็บข้อมูล Stock
	- pub string Symbol{get;set;}, pub float Price{get;set;} Constructor(Symbol,Price)
	- pub override string ToString(){return "Stock symbol=..,price=.."}
- Class StockBar implement IObserver<Stock>: เก็บข้อมูล Stock
	- pri List<Stock> _stocks = new List<Stock>();
	- void AddStock(Stock stock){if(_stocks.Contains(stock))=>_stocks.Remove(stock)
	else =>_stocks.Add(stock)} //ตอนAdd ถ้าเจออันเดิมให้เอาอันเก่าออก และเอาอันใหม่เข้า
	- pub void OnCompleted(){Console.WL("Done!")//จบงาน ทำ Console.WL(..)
	- pub void OnNext(Stock value){AddStock(value); Show();} //สำหรับใช้ notifyObserver
	- pub void Show(){Con.WL('=StockList=');for(var stock in _stocks){con.WL('stockbar:stock');
		con.wl('--')}
- Class Unsubscriber implement IDisposable: ใช้ในขั้นตอนการ Subscribe
	- pri List<IObserver<Stock>> _observers; pri IObserver<Stock> _observer;
	- Constructor(List<..>observers,IOb..<Stock> observer)=> _observers=ob..s,_observ=observer)
	- pub void Dispose(): if(_observers!=null){_observers.Remove(_observer);
		- เป็นการลบobserver ออกจาก observersList
- Class StockProvider implement IObservable<Stock>
	- pri List<IObserver<Stock>> _observers; pri List<Stock> _stocks;
	- pri List<Stock> _stocks; Constructor()=>_observer=newList<IObserver<Stock>>();,_stocks=newList
	- pub void AddStock(Stock value){เหมือน AddStock ใน Stockbar; NotifyObserver(value)}
	- pub IDisposable Subscribe(IObserver<Stock> observer) //IDisposable ใช้คุยกับ Class Stockbar
		- if(!_observers.Contains(observer)){_observers.Add(observer);}
		- return new Unsubscriber(_observers,observer); //ต้อง return Unsubscriber(เป็นtypeIDisposable)
	- pri void NotifyObserver(Stock value){foreach(var observer in _observers){
		observer.OnNext(value);}} // forloop เรียก Stockbar มา Onnext
	- pub void EndNotifyObserver() {foreach(var observer in _observers){observer.OnCompleted()}
		- จบ กระบวนการ Observe => เรียก StockBar มา OnCompleted()

ตัวอย่างใน Program.cs
```
            // Create provider
            var provider = new StockProvider();
            // Create observer
            var stockbar1 = new StockBar();
			provider.Subscribe(stockbar1); // provider Subscribe stockbar(Observer)
			provider.AddStock(new Stock("GOOG", 10));
            provider.AddStock(new Stock("MFT", 20));
            provider.AddStock(new Stock("GOOG", 15));
			// Push information
            provider.AddStock(new Stock("GOOG", 10));
            provider.AddStock(new Stock("MFT", 20));
            provider.AddStock(new Stock("GOOG", 15));
            // OnComplete
            provider.EndNotifyObserver();
	Output:
	===== STOCK LIST =========
===== STOCK LIST =========
STOCK BAR:Stock{symbol='GOOG', price=10}
==========================
===== STOCK LIST =========
STOCK BAR:Stock{symbol='GOOG', price=10}
STOCK BAR:Stock{symbol='MFT', price=20}
==========================
===== STOCK LIST =========
STOCK BAR:Stock{symbol='MFT', price=20}
STOCK BAR:Stock{symbol='GOOG', price=15}
==========================
Done!
```

Design ถ้าให้ Stockbar =subscribe,Unsubscribe> StockProvider:
- Class Stockbar เพิ่ม: prop pri IDisposable _unsubscriber; //เป็นตัวยกเลิกการรับข้อมูล
	- pub void Subscribe(IObservable<Stock> provider){_unsubscriber = provider.Subscribe(this)}
	- pub void Unsubscribe(){if(_unsubscriber!=null){_unsubscriber.Dispose();}
- Program.cs	
```
            var provider = new StockProvider();
            var stockbar1 = new StockBar();
			//stocbar(Observer) Subscribe provider
            stockbar1.Subscribe(provider); 
			provider.AddStock(new Stock("GOOG", 10));
            provider.AddStock(new Stock("MFT", 20));
            provider.AddStock(new Stock("GOOG", 15));

            // Unsubscribe
            stockbar1.Unsubscribe();
            // No push information
            provider.AddStock(new Stock("GOOG", 25));
            // Resubscribe
            stockbar1.Subscribe(provider);
            provider.AddStock(new Stock("GOOG", 25));
            // OnComplete
            provider.EndNotifyObserver();
Output:
	===== STOCK LIST =========
STOCK BAR:Stock{symbol='GOOG', price=10}
==========================
===== STOCK LIST =========
STOCK BAR:Stock{symbol='GOOG', price=10}
STOCK BAR:Stock{symbol='MFT', price=20}
==========================
===== STOCK LIST =========
STOCK BAR:Stock{symbol='MFT', price=20}
STOCK BAR:Stock{symbol='GOOG', price=15}
==========================
===== STOCK LIST =========
STOCK BAR:Stock{symbol='MFT', price=20}
STOCK BAR:Stock{symbol='GOOG', price=25}
==========================
===== STOCK LIST =========
STOCK BAR:Stock{symbol='MFT', price=20}
STOCK BAR:Stock{symbol='GOOG', price=25}
==========================
Done!

```
ตัวอย่างนี้ ถ้าใช้ provider.subscribe แทน แล้วใช้ stockbar1.Unsubscribe()
แล้วจะไม่สามารถ Unsubsribe ได้ เพราะ stockbar กับ provider แยก ส่วนกัน
provider ไม่ได้เขียน method unsub