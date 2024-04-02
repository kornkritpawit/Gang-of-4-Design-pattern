using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_mediator;

namespace pattern_mediator
{
    public class UIControl // Mediator คุยกัน
    {
        protected DialogBox _owner;

        public UIControl(DialogBox owner)
        {
            _owner = owner;
        }
    }
}