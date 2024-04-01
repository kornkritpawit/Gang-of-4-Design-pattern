// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace observer_pattern
// {
//     public class test
//     {
//         static void Main(string[] args)
//         {
//             var dataSource1 = new DataSource();
//             var sheet1 = new PullingSpreadSheet(dataSource1);
//             var sheet2 = new PullingSpreadSheet(dataSource1);
//             var chart1 = new PullChart(dataSource1); 

//             dataSource1.AddObserver(sheet1);
//             dataSource1.AddObserver(sheet2);
//             dataSource1.AddObserver(chart1);
//             dataSource1.Data = 20;
//         }
//     }
// }