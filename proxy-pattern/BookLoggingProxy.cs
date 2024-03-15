using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_proxy;

namespace proxy_pattern
{
    public class BookLoggingProxy : IBook
    {
        public string fileName {get; }
        private RealBook realBook;

        public BookLoggingProxy(string fileName)
        {
            this.fileName = fileName;
        }

        public void Show()
        {
            if (realBook == null) {
                realBook = new RealBook(fileName);
            }
            System.Console.WriteLine("Logging book " + fileName);
            realBook.Show();
            //หน้าที่เหมือน BookProxy แต่เพิ่ม print
        }
    }
}