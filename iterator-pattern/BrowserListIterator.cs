using System.Collections.Generic;

namespace pattern_iterator
{
    public class BrowserListIterator
    {
        private List<BrowserHistory> _histories;
        private int _index;
        public BrowserListIterator()
        {
            _histories = new List<BrowserHistory>();
            _index = 0;
        }
        public void PushHistory(BrowserHistory history)
        {
            _histories.Add(history); //List
            _index += 1;
        }
        public BrowserHistory PopHistory() {
            var lastElement = _histories[_index];
            _histories.RemoveAt(_index); // List
            _index -= 1;
            return lastElement;
        }
        public Iterator<BrowserHistory> CreateIterator() {
            return new ListIterator(this);
        }
        // nested class
        public class ListIterator : Iterator<BrowserHistory> {
            private readonly BrowserListIterator _browser;
            private int _index;
            public ListIterator(BrowserListIterator browser)
            {
                _browser = browser;
                _index = 0;
            }
            public BrowserHistory Current()
            {
                return _browser._histories[_index]; 
            }
            public bool HasNext()
            {
                return _index < _browser._histories.Count;
            }
            public void Next()
            {
                _index+=1;
            }
        } 
    }
}