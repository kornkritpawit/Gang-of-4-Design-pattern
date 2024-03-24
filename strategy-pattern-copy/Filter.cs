using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace strategy_pattern
{
    public interface Filter
    {
        void Filter(string fileName);
    }
}