# Command Pattern

- Starter project: https://github.com/utarn/csharp-design-pattern-command/tree/7af70cfda0905a29b5a6f648899b80be64a6d46f
- Finish project: https://github.com/utarn/csharp-design-pattern-command
# Command Pattern
ออกแบบมาเพื่อแก้ไขปัญหาความเข้ากันได้ระหว่าง library 2 package ที่ถูกสร้างมาไม่พร้อมกัน เช่น ในขั้นตอนการออกแบบ framework นั้น ผู้ออกแบบ framework ไม่สามารถทราบล่วงหน้าได้เลยว่า class ที่ถูกออกแบบนี้จะถูกสั่งให้ทำงานอะไร เช่น class Button ผู้ออกแบบสามารถออกแบบปุ่ม และลักษณะการทำงานเพื่อตอบสนองการคลิกได้ แต่การที่ปุ่มหนึ่งจะคลิกแล้วเกิดเหตุการณ์อะไรนั้น เป็นเรื่องของนักพัฒนาแอพลิกเคชันที่นำไปใช้ต่อ ดังนั้น Command pattern จึงถูกออกแบบมาให้ผู้พัฒนาสามารถกำหนดพฤติกรรมของ Button ได้โดยที่ไม่ต้องแก้ไข class Button ที่มากับ framework

# Command Pattern
Command pattern ถูกออกแบบมา เพื่อแก้ไขปัญหาความเข้ากันได้ระหว่าง library 2 package ที่ถูกสร้างมาไม่พร้อมกัน 
เช่น class Button ที่เป็น Builtin Library เราไม่รู้ว่า Click() และมี Library Customerservice, OrderService 
ซึ่งถ้า Click แล้วให้ใช้ Customerservice หรือ OrderService ต่อ แล้วเราจะ Design การเขียนโค้ดยังไง 
ให้คนที่มาพัฒนาโค้ดต่อสามารถเข้าใจโค้ดได้ง่ายขึ้น รู้เลยว่าคลิ้กแล้วปุ่มจะทำงานอะไร

Design:
- สร้าง **Interface Command**: void Execute(); ไว้ให้ คลาส service มา implement
- Class Button:
	- str Text, public Command OnClick {get;, set;}, Click(){OnClick.Execute()}
- Class Order Service: void AddCustomer(): void AddCustomer(), Class OrderService: void AddOrder() ซึ่งจะถูกเรียกใช้งานโดย Class XXCommand
- Class AddCustomerCommand implement Command: Constructor(รับ customerService), void Execute(){customerService.AddCustomer()} / AddOrderCommand หลักการเหมือนกัน

ตัวอย่างใน Program.cs
```
            var button1 = new Button();
            var customerService = new CustomerService();
            var addCustomerCommand = new AddCustomerCommand(customerService);
            button1.OnClick = addCustomerCommand;
            button1.Click()
 ```
กรณีที่ OnClick ต้องการให้ใช้ Service หลาย Service:
- สร้าง Class CompositeCommand implement Command:
	- property public List<Command> Commands {ge; private set;}
	- Constructor สร้าง Commands เป็น List<Command> เปล่า เพื่อรอ Add ฟังก์ชั่นใหม่เข้ามา
	- void Execute() ทำการ foreach ใน List<Command> และ ทำการ Execute() ตัวที่่วนลูป

ตัวอย่างใน Program.cs
```
            var compositeCommand = new CompositeCommand();
            compositeCommand.Commands.Add(addCustomerCommand);
            compositeCommand.Commands.Add(new AddOrderCommand(new OrderService()));

            button1.OnClick = compositeCommand;
            button1.Click();
```

ถ้าอยากทำ การ Undo (แบบเก็บ เงื่อนไข หรือ function ก่อนหน้า โดยที่ไม่ได้เก็บ data ทั้งหมด)
- มี Class HtmlDocument: string Content{get; set;}, void MakeBold() ทำตัวหน้า
- สร้าง Interface UndoableCommand ที่ implement Interface Command: void UnExecute();
- สร้าง Class History เพื่อเก็บประวัติ การใช้ Command
    - private Stack<UndoableCommand> histories โดย มี Constructor สร้าง Stack เปล่าในตอนเริ่มต้น
    - void Push(UndoableCommand command), Pop {histories.Pop()}
- Class UndoCommand Implement UndoableCommand: Constructor(รับและ set History history)
    - void Execute() เช็ค history.Size > 0 ก็จะ ดึง Command ตัวสุดท้ายใน history มาทำการ UnExecute()
- Class MakeBoldCommand Implement UndoableCommand:
    - str _previousConetnt, HtmlDocument _htmlDocument, History history
    - Generate Constructor (_htmlDocument, history)
    - void Execute(): _previousContent = _htmlDocument.Content; _htmlDocument.MakeBold(); _history.Push(this);
    - void UnExecute(): _htmlDocument.Content = _previousContent;

ตัวอย่าง Program.cs
```
            var htmlDocument = new HtmlDocument();
            htmlDocument.Content = "Hello Design Pattern!";
            Console.WriteLine(htmlDocument);
            var history = new History();
            var makeBoldCommand = new MakeBoldCommand(htmlDocument, history);
            var boldButton = new Button();
            boldButton.OnClick = makeBoldCommand;
            boldButton.Click();
            Console.WriteLine(htmlDocument);

            var undoButton = new Button();
            var UndoCommand = new UndoCommand(history);
            undoButton.OnClick = UndoCommand;
            undoButton.Click();
            Console.WriteLine(htmlDocument);
```