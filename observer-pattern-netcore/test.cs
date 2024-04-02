using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace observer_pattern_netcore
{
    public class test
    {
        static void Main(string[] args)
        {
            // Create provider
            var provider = new StockProvider();
            // Create observer
            var stockbar1 = new StockBar();
            // provider Subscribe stockbar(Observer)
            provider.Subscribe(stockbar1); 
            // Push information
            provider.AddStock(new Stock("GOOG", 10));
            provider.AddStock(new Stock("MFT", 20));
            provider.AddStock(new Stock("GOOG", 15));
            // Unsubscribe
            stockbar1.Unsubscribe();
            Console.WriteLine("-Unsubscribe-");
            // No push information
            provider.AddStock(new Stock("GOOG", 25));
            Console.WriteLine("-No push information- new Stock(GOOG, 25)");
            // Resubscribe
            stockbar1.Subscribe(provider);
            provider.AddStock(new Stock("GOOG", 40));
            // OnComplete
            provider.EndNotifyObserver();
        }
    }
}