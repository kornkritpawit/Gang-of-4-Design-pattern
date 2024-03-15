# Proxy  Pattern Conclude
- Starter project: https://github.com/utarn/csharp-pattern-proxy/tree/eb2021810c0f3083086c2207154cbbf101ea6a37
- Finish project: https://github.com/utarn/csharp-pattern-proxy/tree/671bfeef22089b8e4d4d9bf8d460fda4ef8a298b

# Proxy  Pattern Conclude
ช่วยสร้างคลาสที่เป็นตัวแทนคลาสเดิม โดยคลาสตัวแทนจะเป็นตัวส่งผ่านการทำงานไปยังวัตถุคลาสจริง
โดยที่เราสามารถเพิ่มคุณสมบัติให้กับวัตถุคลาสจริงได้ ในปัจจุบันนิยมใช้เป็นคุณสมบัติ Lazy loading 
ในเครื่องมือประเภท ORM (Object Relational Mapping) ยกตัวอย่างเช่น 
เรามีคลาสหนังสือที่บรรจุเนื้อหาและชื่อหนังสือ เมื่อโหลดหนังสือทุกเล่มเข้าไปในห้องสมุดจะใช้พื้นที่หน่วยความจำมากเกินไป 
Proxy pattern จะช่วยให้เราแยกโหลดเฉพาะชื่อหนังสือ และ
โหลดเนื้อหาของหนังสือเมื่อจำเป็นโดยที่ไม่ต้องแก้ไขคลาสของหนังสือเดิม

Design1:
- class Book: pub str fileName{get;} constructor(str fileName){this.fileName=fileName; Load()}
	- pri void Load() {sys.cwl("Loading book "+fileName)}
	- pub void Show() {sys.cwl("Showing book "+fileName)}
- class Library: pri Dictionary<str, Book> books = new Dictionary<str, Book>();
	- pub void AddBook(Book book) {books.Add(book.fileName, book);}
	- pub void OpenBook(str fileName){if(books.ContainsKey(fileName)){
		book[fileName].Show();} else{ //ShowError!// }}
ตัวอย่างใน Program.cs
```
	var library = new LibraryPy(); string[] fileNames = {"a","b","c"};
	foreach (var fileName in fileNames) {library.AddBook(new Book(fileName));}
	library.OpenBook("a");
output:
Loading book a
Loading book b
Loading book c
Showing book a
```
ปัญหาของ Design1: Loading book a,b,c ในความจริงถ้าหนังสือเยอะจะโหลดเข้าเมมเยอะ
- OpenBook("a")ต้องการโชว์แค่ a แต่ต้องโหลดหนังสือ 3 เล่ม ทำให้เปลือง mem

Design 2:
- สร้าง Interface IBook: str fileName {get;} void Show();
- class RealBook implement IBook: pub str fileName{get;} 
	- constructor(str fileName){this.fileName=fileName; Load()}
	- pri void Load() {sys.cwl("Loading book "+fileName)}
	- pub void Show() {sys.cwl("Showing book "+fileName)}
- class Library: pri Dictionary<str, IBook> books = new Dictionary<str, IBook>();
	- pub void AddBook(IBook book) {books.Add(book.fileName, book);}
	- pub void OpenBook(str fileName){if(books.ContainsKey(fileName)){
		book[fileName].Show();} else{ //ShowError!// }}
- class BookProxy: pub str fileName {get;} pri RealBook realBook;
	- constructor(str fileName){this.fileName=fileName;}
	- pub void Show() {if(realBook==null){realBook = new RealBook(fileName);} realBook.Show();}
- class BookLoggingProxy implement IBook: pub str fileName {get;} pri RealBook realBook;
	- constructor(str fileName){this.fileName=fileName;}
	- pub void Show() {if(realBook==null){realBook = new RealBook(fileName);} 
		sys.cwl("Logging book "+fileName); realBook.Show();} //เหมือนเดิม เพิ่ม log

ตัวอย่างใน Program.cs
```
	var library = new LibraryPy(); string[] fileNames = {"a","b","c"};
    foreach (var fileName in fileNames)
    {
        // library.AddBook(new BookProxy(fileName));
        // library.AddBook(new BookLoggingProxy(fileName));
        // library.AddBook(new RealBook(fileName)); // โหลดทุกเล่ม
    }
	library.OpenBook("a");
	library.OpenBook("b");
Output case library.AddBook(new BookProxy(fileName));
	Loading book a
	Showing book a
	Loading book b
	Showing book b
Output case library.AddBook(new BookLoggingProxy(fileName));
	Loading book a
	Logging book a
	Showing book a
	Loading book b
	Logging book b
	Showing book b
Output case library.AddBook(new RealBook(fileName)); Realbook โหลดทุกเล่ม
	Loading book a
	Loading book b
	Loading book c
	Showing book a
	Showing book b
```
Proxy เหมือน lazy loading ใน database พอจะใช้ค่อยไป query มา
วีธีนี้ เพิ่ม performance ของ Book โดยไม่ต้องแก้ class Book