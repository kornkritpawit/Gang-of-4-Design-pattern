using System;
using observer_pattern;

namespace pattern_observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSource1 = new DataSource();
            var sheet1 = new SpreadSheet();
            var sheet2 = new SpreadSheet();
            var chart1 = new Chart();

            // dataSource1.AddObserver(sheet1);
            // dataSource1.AddObserver(sheet2);
            // dataSource1.AddObserver(chart1);
            // dataSource1.Data = 10;

            var sheet3 = new PullingSpreadSheet(dataSource1);
            var sheet4 = new PullingSpreadSheet(dataSource1);
            var chart2 = new PullChart(dataSource1);
            dataSource1.AddObserver(sheet3);
            dataSource1.AddObserver(sheet4);
            dataSource1.AddObserver(chart2);
            dataSource1.Data = 20;
        }
    }
}