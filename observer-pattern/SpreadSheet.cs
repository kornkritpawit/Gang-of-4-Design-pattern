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

    public class PullingSpreadSheet : ObServer
    {
        private DataSource _dataSource;

        public PullingSpreadSheet(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        // public void Update()
        // {
        //     Console.WriteLine("Got notified from datasource");
        // }

        public void Update()
        {
            Console.WriteLine("Got notified from datasource: " + _dataSource.Data);
        }
    }

}