using System;
using observer_pattern;
namespace pattern_observer
{
    public class Chart : ObServer<int>
    {
        public void Update()
        {
            Console.WriteLine("Got notified from datasource: Chart");
        }

        public void Update(int value)
        {
            Console.WriteLine("Got notified from dataSource: " + value);
        }
    }

    public class PullChart : ObServer
    {
        private DataSource _dataSource;

        public PullChart(DataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public void Update()
        {
            Console.WriteLine("Got notified from datasource: " + _dataSource.Data);
        }
    }
}