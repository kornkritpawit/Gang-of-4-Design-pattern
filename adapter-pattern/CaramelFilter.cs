using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_adapter.AvaFilter;

namespace adapter_pattern
{
    public class CaramelFilter : Filter
    {
        private Caramel _caramel;

        public CaramelFilter(Caramel caramel)
        {
            _caramel = caramel;
        }

        public void Apply(Image image)
        {
            _caramel.Init();
            _caramel.Render(image);
        }
    }
}