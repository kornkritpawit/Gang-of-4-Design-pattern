using System;
using observer_pattern_netcore;

namespace pattern_observer_netcore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create provider
            var provider = new StockProvider();
            // Create observer
            var stockbar1 = new StockBar();
            
            provider.Subscribe(stockbar1); // provider Subscribe stockbar(Observer)
            // stockbar1.Subscribe(provider); //stocbar(Observer) Subscribe provider

            // Push information
            provider.AddStock(new Stock("GOOG", 10));
            provider.AddStock(new Stock("MFT", 20));
            provider.AddStock(new Stock("GOOG", 15));

            // Unsubscribe
            stockbar1.Unsubscribe();
            // No push information
            provider.AddStock(new Stock("GOOG", 25));
            // Resubscribe
            stockbar1.Subscribe(provider);
            provider.AddStock(new Stock("GOOG", 25));

            // OnComplete
            provider.EndNotifyObserver();
        }
    }
}