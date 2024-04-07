using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_visitor;

namespace visitor_pattern
{
    public class AnchorNode : HtmlNode
    {
        public void Execute(Operation operation)
        {
            operation.Apply(this);
        }
    }
}