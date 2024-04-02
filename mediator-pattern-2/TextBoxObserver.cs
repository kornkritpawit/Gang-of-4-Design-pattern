using mediator_pattern;

namespace pattern_mediator
{
    public class TextBoxObserver : UIControlObserverPt
    {
        private string _text;

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                NotifyEventHandlers();
            }
        }
    }
}