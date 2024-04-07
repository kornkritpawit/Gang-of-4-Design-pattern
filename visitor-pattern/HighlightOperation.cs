using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace visitor_pattern
{
    public class HighlightOperation : Operation
    {
        public void Apply(HeadingNode node)
        {
            Console.WriteLine("highlight-heading");
        }
        public void Apply(AnchorNode node)
        {
            Console.WriteLine("highlight-anchor");
        }
    }
}