using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_proxy;

namespace proxy_pattern
{
    public class LibraryPy
    {
        private Dictionary<string, IBook > books = new Dictionary<string, IBook>();
        public void AddBook(IBook book)
        {
            books.Add(book.fileName, book);
        }
        public void OpenBook(string fileName)
        {
            if (books.ContainsKey(fileName))
            {
                books[fileName].Show();
            }
            else
            {
                // Show error!
            }
        }
    }
}