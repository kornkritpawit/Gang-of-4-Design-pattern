using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adapter_pattern
{
    public class VividFilter : Filter
    {
        public void Apply(Image image)
        {
            System.Console.WriteLine("Applying vivid filter");
        }
    }
}