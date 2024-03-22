using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace pattern_iterator_netcore
{
    public class Browser : IEnumerable<BrowserHistory>
    {
        private List<BrowserHistory> _histories;
        public Browser()
        {
            _histories = new List<BrowserHistory>();
        }
        public void PushHistory(BrowserHistory history)
        {
            _histories.Add(history);
        }
        public BrowserHistory PopHistory()
        {
            var lastElement = _histories[^1]; //^1=ตัวสุดท้าย, ^2=ตัวรองสุดท้าย
            _histories.Remove(lastElement);
            return lastElement;
        }

        public IEnumerator<BrowserHistory> GetEnumerator()
        {
            // มี function นี้เพราะ ใช้ type IEnumerable<BrowserHistory>
            // Cask ให้เป็น BrowserHistory
            return new ListIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class ListIterator : IEnumerator<BrowserHistory>
        {
            private readonly Browser _browser;
            private int _index;
            public ListIterator(Browser browser) {
                _browser =browser;
                _index = -1;
            }
            public BrowserHistory Current => _browser._histories[_index];
            // มี function นี้เพราะ ใช้ type IEnumerable<BrowserHistory>
            // Cask ให้เป็น BrowserHistory

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext() // = Next() and HasNext รวมกัน
            {
                _index++;
                return _index < _browser._histories.Count;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}