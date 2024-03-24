using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace strategy_pattern
{
    public class HighContrastFilter : Filter
    {
        public void Filter(string fileName)
        {
            Console.WriteLine("Applying high contrast filter");
        }
    }
}