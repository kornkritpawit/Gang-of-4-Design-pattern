using mediator_pattern;

namespace pattern_mediator
{
    public class ListBoxObserver : UIControlObserverPt
    {
        private string _selection;

        public string Selection
        {
            get
            {
                return _selection;
            }
            set
            {
                _selection = value;
                NotifyEventHandlers();
            }
        }
    }
}