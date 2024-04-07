using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_visitor;

namespace visitor_pattern
{
    public class AnchorNode : HtmlNode
    {
        // public void Highlight()
        // {
        //     Console.WriteLine("highlight-anchor");
        // }
        // public void PlainText()
        // {
        //     Console.WriteLine("text-anchor");
        // }
        public void Execute(Operation operation)
        {
            operation.Apply(this);
        }
    }
}