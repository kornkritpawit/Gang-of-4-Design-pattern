// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using pattern_observer;

// namespace observer_pattern
// {
//     public class Subject
//     {
//         private List<ObServer<int>> _observers;
//         public Subject()
//         {
//             _observers = new List<ObServer<int>>();
//         }
//         public void AddObserver(ObServer<int> obServer)
//         {
//             _observers.Add(obServer);
//         }
//         public void RemoveObserve(ObServer<int> obServer)
//         {
//             _observers.Remove(obServer);
//         }
//         public void NotifyObserver(int value)
//         {
//             foreach (var observer in _observers)
//             {
//                 observer.Update(value);
//             }
//         }
//     }

// }