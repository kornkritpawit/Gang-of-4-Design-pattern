using System.Collections.Generic;

namespace pattern_iterator
{
    public class BrowserArrayIterator
    {
        // private List<BrowserHistory> _histories;
        // public List<BrowserHistory> Histories => _histories;

        private BrowserHistory[] _histories;
        private int _index;
        public BrowserArrayIterator()
        {
            // _histories = new List<BrowserHistory>();

            _histories = new BrowserHistory[10];
            _index = 0;
        }

        public void PushHistory(BrowserHistory history)
        {
            // _histories.Add(history); //List
            _histories[_index] = (history); //Array

            _index += 1;
        }

        public BrowserHistory PopHistory() {
            var lastElement = _histories[_index];
            // _histories.RemoveAt(_index); // List
            _histories[_index] = null;
            _index -= 1;
            return lastElement;
        }

        public Iterator<BrowserHistory> CreateIterator() {
            // return new ListIterator(this);
            return new ArrayIterator(this);
        }

        // nested class

        public class ArrayIterator : Iterator<BrowserHistory>
        {
            private readonly BrowserArrayIterator _browser;
            private int _index;
            public ArrayIterator(BrowserArrayIterator browser)
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
                return _index < _browser._index;
            }

            public void Next()
            {
                _index++;
            }
        }
    }
}