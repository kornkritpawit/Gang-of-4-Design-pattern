using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_iterator;

namespace iterator_pattern
{
    public class test
    {
        static void Main(string[] args)
        {
            var browser = new BrowserListIterator();
            var history1 = new BrowserHistory("a", DateTime.Now);
            var history2 = new BrowserHistory("b", DateTime.Now.AddMinutes(10));
            var history3 = new BrowserHistory("c", DateTime.Now.AddHours(1));

            browser.PushHistory(history1);
            browser.PushHistory(history2);
            browser.PushHistory(history3);

            var iterator = browser.CreateIterator();
            while (iterator.HasNext())
            {
                var currentHistory = iterator.Current();
                Console.WriteLine(currentHistory);
                iterator.Next();
            }
        }
    }
}