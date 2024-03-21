using System.Collections.Generic;

namespace pattern_iterator
{
    public class BrowserArray
    {
        private BrowserHistory[] _histories;
        public BrowserHistory[] Histories => _histories;
        private int _index;
        public BrowserArray()
        {
            _histories = new BrowserHistory[10];
            _index = 0;
        }
        public void PushHistory(BrowserHistory history)
        {
            _histories[_index] = (history); //Array
            _index += 1;
        }
        public BrowserHistory PopHistory()
        {
            var lastElement = _histories[_index];
            _histories[_index] = null;
            _index -= 1;
            return lastElement;
        }
    }
}