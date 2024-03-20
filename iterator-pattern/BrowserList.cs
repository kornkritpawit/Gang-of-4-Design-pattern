using System.Collections.Generic;

namespace pattern_iterator
{
    public class BrowserList
    {
        private List<BrowserHistory> _histories;
        public List<BrowserHistory> Histories => _histories;

        private int _index;
        public BrowserList()
        {
            _histories = new List<BrowserHistory>();
            _index = 0;
        }

        public void PushHistory(BrowserHistory history)
        {
            _histories.Add(history); //List
            _histories[_index] = (history);

            _index += 1;
        }

        public BrowserHistory PopHistory() {
            var lastElement = _histories[_index];
            _histories.RemoveAt(_index); // List
            _index -= 1;
            return lastElement;
        }

    }
}