using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace strategy_pattern
{
    public class BlackWhiteFilter : Filter
    {
        public void Filter(string fileName)
        {
            Console.WriteLine("Applying B&W filter");
        }
    }
}