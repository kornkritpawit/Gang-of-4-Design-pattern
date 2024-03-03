using System;

namespace pattern_iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var browser = new Browser();
            var history1 = new BrowserHistory("a", DateTime.Now);
            var history2 = new BrowserHistory("b", DateTime.Now.AddMinutes(10));
            var history3 = new BrowserHistory("c", DateTime.Now.AddHours(1));

            browser.PushHistory(history1);
            browser.PushHistory(history2);
            browser.PushHistory(history3);

            // for (int i = 0; i < browser.Histories.Count; i++) //แบบดั้งเดิม วิธีเก่า
            // {
            //     Console.WriteLine(browser.Histories[i]);
            // }

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