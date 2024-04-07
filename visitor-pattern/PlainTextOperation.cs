using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace visitor_pattern
{
    public class PlainTextOperation : Operation
    {
        public void Apply(HeadingNode node)
        {
            Console.WriteLine("text-heading");
        }
        public void Apply(AnchorNode node)
        {
            Console.WriteLine("text-anchor");
        }
    }
}