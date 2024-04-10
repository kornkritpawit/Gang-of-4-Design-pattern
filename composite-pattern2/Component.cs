using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace composite_pattern
{
    public interface Component
    {
        public void Render();
        void Move();
    }
}