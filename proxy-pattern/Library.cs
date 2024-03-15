using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_proxy;

namespace proxy_pattern
{
    public class Library
    {
        private Dictionary<string, Book> books = new Dictionary<string, Book>();
        public void AddBook(Book book)
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