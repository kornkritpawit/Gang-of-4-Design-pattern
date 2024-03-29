using System;
using observer_pattern;
namespace pattern_observer
{
    public class SpreadSheet : ObServer
    {
        public void Update()
        {
            Console.WriteLine("Got notified from datasource: SpreadSheet");
        }
    }
}