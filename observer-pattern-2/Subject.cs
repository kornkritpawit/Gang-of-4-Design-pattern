using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_observer;

namespace observer_pattern
{
    public class Subject //เป็น Super class ให้ DataSource มาสืบทอด
    {
        //ข้อเสียของ ObServer<T> คือถ้าแก้ Type ก็ต้องแก้เยอะหลายไฟล์ 
        // private List<ObServer<int>> _observers; 
        private List<ObServer> _observers;
        public Subject()
        {
            // _observers = new List<ObServer<int>>();
            _observers = new List<ObServer>();
        }
        public void AddObserver(ObServer obServer)
        {
            _observers.Add(obServer);
        }
        public void RemoveObserve(ObServer obServer)
        {
            _observers.Remove(obServer);
        }
        public void NotifyObserver(int value)
        {
            foreach (var observer in _observers)
            {
                // observer.Update(value);
                observer.Update();
            }
        }
    }

}