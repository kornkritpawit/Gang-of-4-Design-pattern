using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decorator_pattern
{
    public interface Stream
    {
        void Write(string data);
    }
}