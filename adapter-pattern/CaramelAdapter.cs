using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_adapter.AvaFilter;

namespace adapter_pattern
{
    public class CaramelAdapter : Caramel, Filter
    {
        public void Apply(Image image)
        {
            Init();
            Render(image);
            
        }
    }
}