using System;
using observer_pattern;
namespace pattern_observer
{
    public class SpreadSheet : ObServer<int>
    {
        public void Update()
        {
            Console.WriteLine("Got notified from datasource: SpreadSheet");
        }

        public void Update(int value)
        {
            Console.WriteLine("Got notified from dataSource: " + value);
        }
    }
}
