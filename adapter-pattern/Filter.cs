using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adapter_pattern
{
    public interface Filter
    {
        void Apply(Image image);
    }
}