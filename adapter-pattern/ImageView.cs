using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adapter_pattern
{
    public class ImageView
    {
        private Image _image;
        public ImageView(Image image)
        {
            _image = image;
        }
        public void Apply(Filter filter) {
            filter.Apply(_image);
        }
    }
}