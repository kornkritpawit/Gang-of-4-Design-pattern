using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_mediator;

namespace mediator_pattern
{
    public class Button : UIControl
    {
        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                NotifyEventHandlers();
            }
        }
    }
}