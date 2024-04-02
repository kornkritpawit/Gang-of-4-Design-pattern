using mediator_pattern;

namespace pattern_mediator
{
    public class TextBox : UIControl
    {
        private string _text;

        public TextBox(DialogBox owner) : base(owner)
        {
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                _owner.OnChanged(this);
            }
        }
    }
}