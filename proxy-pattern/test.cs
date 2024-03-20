// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace proxy_pattern
// {
//     public class test
//     {
//         static void Main(string[] args)
//         {
//             var library = new Library();
//             string[] fileNames = {"a","b","c"};
//             foreach (var fileName in fileNames)
//             {
//                 library.AddBook(new BookLoggingProxy(fileName));
//             }
//             library.OpenBook("a");           
//             library.OpenBook("b");
//         }
//     }
// }

// static void Main(string[] args)
//         {
//             var library = new Library();
//             string[] fileNames = {"a","b","c"};
//             foreach (var fileName in fileNames)
//             {
//                 library.AddBook(new Book(fileName));
//                 // library.AddBook(new BookLoggingProxy(fileName));
//                 // library.AddBook(new RealBook(fileName)); // โหลดทุกเล่ม
//             }
//             // Loading book a,b,c 
//             //ในความจริงถ้า หนังสือเยอะ โหลดเข้าเมมเยอะ
//             library.OpenBook("a");
//             // ต้องการโชว์แค่ a แต่ต้องโหลดหนังสือ 3 เล่ม
//             // จะเพิ่มประสิทธิ ภาพของ Book ยังไงโดยไม่ต้องแก้ไข class Book
//             // สร้าง Interface 

//             // library.OpenBook("b");
//             // Proxy เหมือน lazy loading ใน database พอจะใช้ค่อยไป query มา

//         }