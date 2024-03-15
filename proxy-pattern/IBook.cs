using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proxy_pattern
{
    public interface IBook
    {
        string fileName {get;}
        void Show();
    }
}