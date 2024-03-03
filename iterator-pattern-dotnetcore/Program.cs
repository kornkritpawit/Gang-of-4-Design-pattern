using System;

namespace pattern_iterator_netcore
{
    class Program
    {
        static void Main(string[] args)
        {
            var browser = new Browser();
            browser.PushHistory(new BrowserHistory("a", new DateTime(2020, 1, 1)));
            browser.PushHistory(new BrowserHistory("b", new DateTime(2020, 1, 2)));
            browser.PushHistory(new BrowserHistory("c", new DateTime(2020, 1, 3)));

            foreach (var history in browser)
            {
                Console.WriteLine(history);
            }
        }
    }
}