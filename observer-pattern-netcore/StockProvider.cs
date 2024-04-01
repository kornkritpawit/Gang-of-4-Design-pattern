using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_observer_netcore;

namespace observer_pattern_netcore
{
    public class StockProvider : IObservable<Stock>
    {
        private List<IObserver<Stock>> _observers;
        private List<Stock> _stocks;
        public StockProvider()
        {
            _observers = new List<IObserver<Stock>>();
            _stocks = new List<Stock>();
        }
        public void AddStock(Stock value)
        {
            if (_stocks.Contains(value))
            {
                _stocks.Remove(value);
            }
            _stocks.Add(value);
            NotifyObserver(value);
        }
        public IDisposable Subscribe(IObserver<Stock> observer)
        {
            // Subscribe ตัว Provider ไปที ่Observer หรือ Observer ไป Provider ก็ได้
            // จะคุยกับผ่าน Interface(ทั้ง 2 Class ไม่รู้จักกันมาก่อน)
            if (!_observers.Contains(observer)) {
                _observers.Add(observer);
            }
            //IDisposable เป็น Object ที่เอาไว้เขียนใช้แล้วทำลายทิ้งจาก Memory
            return new Unsubscriber(_observers, observer);
        }
        private void NotifyObserver(Stock value) {
            foreach (var observer in _observers){
                observer.OnNext(value);
            }
        }
        public void EndNotifyObserver() {
            foreach (var observer in _observers) {
                observer.OnCompleted();
            }
        }
    }
}