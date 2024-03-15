using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_proxy;

namespace proxy_pattern
{
    public class BookProxy : IBook
    {
        public string fileName {get;}
        private RealBook realBook;

        public BookProxy(string fileName)
        {
            this.fileName = fileName;
        }

        public void Show()
        {
            if (realBook == null) {
                realBook = new RealBook(fileName);
            }
            realBook.Show();
        }
    }
}