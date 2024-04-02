using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pattern_mediator
{
    public class UIControlObserverPt
    {
        private List<Action> _eventHandlers = new List<Action>();
        public void AddEventHandler(Action observer) {
            _eventHandlers.Add(observer);
        }

        protected void NotifyEventHandlers() {
            foreach (var eventHandlers in _eventHandlers)
            {
                eventHandlers.Invoke(); //สั่งให้มันทำงาน
            }
        }
    }
}